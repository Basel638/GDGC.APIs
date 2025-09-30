using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities._3___Relationships_Entities
{
    public class StudentAttendSession
    {
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
        public DateTime AttendedAt { get; set; }
        public bool AttendedSession { get; set; } = false;
        
    }
}
