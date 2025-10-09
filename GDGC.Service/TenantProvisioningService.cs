using GDGC.Domain.Contracts;
using GDGC.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Service
{
	public class TenantProvisioningService : IServices
	{
		private readonly string _connectionString;

		public TenantProvisioningService(IConfiguration config)
		{
			_connectionString = config.GetConnectionString("DefaultConnection");
		}

		public async Task CreateTenantSchemaAsync(string schemaName)
		{
			using var connection = new SqlConnection(_connectionString);
			await connection.OpenAsync();

			// 1️⃣ إنشاء الـ Schema لو مش موجودة
			using (var createSchemaCmd = new SqlCommand(
				$"IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '{schemaName}') BEGIN EXEC('CREATE SCHEMA [{schemaName}]') END",
				connection))
			{
				await createSchemaCmd.ExecuteNonQueryAsync();
			}

			// 2️⃣ تشغيل Migration داخل الـ Schema الجديدة
			var optionsBuilder = new DbContextOptionsBuilder<GdgContext>();
			optionsBuilder.UseSqlServer(_connectionString,
				o => o.MigrationsHistoryTable("__EFMigrationsHistory", schemaName));

			//using (var context = new GdgContext(optionsBuilder.Options, schemaName))
			//{
			//	await context.Database.MigrateAsync();
			//}

			// 3️⃣ نسخ كل الجداول من dbo إلى الـ Schema الجديدة
			await CopySchemaAsync("dbo", schemaName);
		}

		private async Task CopySchemaAsync(string sourceSchema, string targetSchema)
		{
			var sql = @"
                DECLARE @SourceSchema NVARCHAR(128) = @src;
                DECLARE @TargetSchema NVARCHAR(128) = @dest;
                DECLARE @SQL NVARCHAR(MAX) = N'';

                -- إنشاء الـ Schema لو مش موجودة
                IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = @TargetSchema)
                BEGIN
                    EXEC('CREATE SCHEMA [' + @TargetSchema + ']');
                END

                -- بناء SQL ديناميكي لكل جدول
                SELECT @SQL = @SQL + '
                IF NOT EXISTS (SELECT * FROM sys.tables t 
                               JOIN sys.schemas s ON t.schema_id = s.schema_id 
                               WHERE t.name = ''' + t.name + ''' AND s.name = ''' + @TargetSchema + ''')
                BEGIN
                    SELECT * INTO [' + @TargetSchema + '].[' + t.name + '] 
                    FROM [' + @SourceSchema + '].[' + t.name + '];
                END
                '
                FROM sys.tables t
                INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                WHERE s.name = @SourceSchema;

                EXEC sp_executesql @SQL;
            ";

			using var connection = new SqlConnection(_connectionString);
			await connection.OpenAsync();

			using var cmd = new SqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@src", sourceSchema);
			cmd.Parameters.AddWithValue("@dest", targetSchema);

			await cmd.ExecuteNonQueryAsync();
		}
	}
}
