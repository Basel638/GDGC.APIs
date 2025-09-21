using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities
{
	public class Session:BaseEntity
	{
		public string Title { get; set; }
		public string ContentUrl { get; set; } // رابط الفيديو أو المادة
		public DateTime SessionDate { get; set; }

	}

}
