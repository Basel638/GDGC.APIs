using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GDGC.Domain.Entities
{
	public class Topic: BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();

    }

}
