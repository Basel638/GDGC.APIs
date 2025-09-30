using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities._3___Relationships_Entities
{
	public class StudentSessionsPerTrack
	{
        public int UserId { get; set; }

        public int SessionId { get; set; }

        public int TrackId { get; set; }

        public User User { get; set; }

        public Session Session { get; set; }

        public Track Track { get; set; }



    }
}
