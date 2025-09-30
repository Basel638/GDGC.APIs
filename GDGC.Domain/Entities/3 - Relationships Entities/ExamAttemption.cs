using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities._3___Relationships_Entities
{
    // Student - Exam - Topic
	public class ExamAttemption
	{
        public int ExamId { get; set; }

        public int TopicId { get; set; }

        public int UserId { get; set; }

        public Exam Exam { get; set; }

        public Topic Topic { get; set; }

        public User User { get; set; }

        public double Grade { get; set; }

        public bool IsPassed { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public int TimeSpent { get; set; }

		public bool IsHighstScore { get; set; }


	}
}
