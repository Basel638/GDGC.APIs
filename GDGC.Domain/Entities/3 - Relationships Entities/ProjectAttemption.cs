using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities._3___Relationships_Entities
{
	// Student - Level - Project
	public class ProjectAttemption
	{
        public int UserId { get; set; }

        public int LevelId { get; set; }

        public int ProjectId { get; set; }

        public User User { get; set; }

        public Level Level { get; set; }

        public Project Project { get; set; }

		public bool IsPassed { get; set; }
        public double Grade { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

        public string GithubLink { get; set; }

		public bool IsHighstScore { get; set; }

	}
}
