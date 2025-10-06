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
			//using var connection = new SqlConnection(_connectionString);
			//await connection.OpenAsync();

			//// 1️⃣ إنشاء الـ Schema لو مش موجود
			//using var cmd = new SqlCommand($"IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '{schemaName}') BEGIN EXEC('CREATE SCHEMA [{schemaName}]') END", connection);
			//await cmd.ExecuteNonQueryAsync();

			//// 2️⃣ تشغيل Migration مخصص
			//var optionsBuilder = new DbContextOptionsBuilder<GdgContext>();
			//optionsBuilder.UseSqlServer(_connectionString, o => o.MigrationsHistoryTable("__EFMigrationsHistory", schemaName));

			//using var context = new GdgContext(optionsBuilder.Options, schemaName);
			//await context.Database.MigrateAsync();



			using var connection = new SqlConnection(_connectionString);
			await connection.OpenAsync();

			// إنشاء الـ Schema لو مش موجود
			using var cmd = new SqlCommand($@"
        IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '{schemaName}')
        BEGIN
            EXEC('CREATE SCHEMA [{schemaName}]')
        END", connection);
			await cmd.ExecuteNonQueryAsync();

			// تهيئة الـ DbContext بالـ schema الجديد
			var optionsBuilder = new DbContextOptionsBuilder<GdgContext>();
			optionsBuilder.UseSqlServer(_connectionString);

			using var context = new GdgContext(optionsBuilder.Options, schemaName);

			// إنشاء الجداول فقط لو مش موجودة
			await context.Database.EnsureCreatedAsync();
		}
	}
}
