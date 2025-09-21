using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities
{
	public class Exam : BaseEntity
	{
		public string Title { get; set; }

        public string ExamUrl { get; set; }
        public DateTime AvailableFrom { get; set; }
		public DateTime AvailableTo { get; set; }
		public int TotalMarks { get; set; }

	
	}

}
