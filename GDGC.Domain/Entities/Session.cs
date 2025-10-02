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

        public string MeetingLink { get; set; }

        public bool IsActive { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        //public string InstructorName { get; set; }
        //public string MentorName { get; set; }


    }

}
