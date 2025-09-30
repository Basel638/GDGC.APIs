using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities._3___Relationships_Entities
{
    public class StudentTrack
    {
        // Student - Track (Many to Many)
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }
        public int LastLevel { get; set; }
    }
}
