using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities
{
    public class AssignmentSubmitions 
    {
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string SubmissionUrl { get; set; }
        public int ObtainedMarks { get; set; }
        public string Feedback { get; set; }
    }
}
