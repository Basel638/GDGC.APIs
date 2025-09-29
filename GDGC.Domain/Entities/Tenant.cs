using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities
{
	public class Tenant : BaseEntity
	{
		public string Name { get; set; }
		public string Slug { get; set; }
		public string SchemaName { get; set; } // GDG Cairo
		public string UniversityName { get; set; }
		public string ContactEmail { get; set; }
		public bool IsActive { get; set; } = true;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}

}
