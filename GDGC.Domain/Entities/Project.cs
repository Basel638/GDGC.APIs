using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities
{
	public class Project : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
        public string ProjectUrl { get; set; }
        public DateTime CreatedAt { get; set; }



    }

}
