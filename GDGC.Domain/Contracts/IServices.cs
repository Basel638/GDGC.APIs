using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Contracts
{
	public interface IServices
	{
		public  Task CreateTenantSchemaAsync(string schemaName);
	}
}
