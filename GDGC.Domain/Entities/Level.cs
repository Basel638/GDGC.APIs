using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities
{
	public class Level : BaseEntity
	{
		public string Name { get; set; } // Level 1, Level 2
		public int Order { get; set; }   // ترتيب المستويات

        public string Description { get; set; }

        public int TrackId { get; set; }	
        public Track Track { get; set; }


    }

}
