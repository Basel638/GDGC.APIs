using GDGC.Domain.Contracts;
using GDGC.Infrastructure;
using GDGC.Service;
using Microsoft.EntityFrameworkCore;

namespace GDGC.APIs
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			
			builder.Services.AddDbContext<GdgContext>(Options =>
			{
				Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddScoped(typeof(IServices), typeof(TenantProvisioningService));

            var app = builder.Build();


            #region Update database and Log Exceptopns using [ILoggerFactory]

            using var scope = app.Services.CreateScope(); 
            var services = scope.ServiceProvider; 
            var _dbContext = services.GetRequiredService<GdgContext>();
            // Ask CLR FOR Creating Objects From DbContex
            var loggerFactory = services.GetRequiredService<ILoggerFactory>(); // for Log Exceptions at Console
            var logger = loggerFactory.CreateLogger<Program>();
            try
            {
                await _dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during migration");
            }

            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}


			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
