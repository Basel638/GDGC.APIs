using GDGC.APIs.Dtos;
using GDGC.Domain.Contracts;
using GDGC.Domain.Entities;
using GDGC.Infrastructure;
using GDGC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GDGC.APIs.Controllers
{
	
	public class TenantsController : ApiBaseController
	{
		private readonly IServices _tenantProvisioningService;
		private readonly GdgContext _gdgContext;

		public TenantsController(IServices tenantProvisioningService , GdgContext gdgContext)
        {
			_tenantProvisioningService = tenantProvisioningService;
			_gdgContext = gdgContext;
		}

        [HttpPost]
		public async Task<IActionResult> CreateTenant([FromBody] CreateTenantRequest request)
		{
			// 1️⃣ Add Tenant row to master DB
			var tenant = new Tenant
			{
				Name = request.Name,	
				UniversityName = request.UniversityName,
				SchemaName = request.SchemaName,
				Slug = request.Slug,
				ContactEmail = request.ContactEmail,
			};

			_gdgContext.Tenants.Add(tenant);
			await _gdgContext.SaveChangesAsync();

			// 2️⃣ Create Schema + Run Migration

			await _tenantProvisioningService.CreateTenantSchemaAsync(request.SchemaName);

			return Ok(new { Message = $"Tenant {tenant.Name} created successfully with Schema {tenant.SchemaName}" });
		}


		[HttpGet]
		public async Task<IActionResult> GetTenants()
		{
			var tenants = await _gdgContext.Tenants
				.Select(t => new
				{
					t.Id,
					t.Name,
					t.UniversityName,
					t.SchemaName,
					t.CreatedAt,
				})
				.ToListAsync();

			return Ok(tenants);
		}
	}
}
