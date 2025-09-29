using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Domain.Entities
{

	public enum Gender
	{
		Male,
		Female,
		female,
		male
	}

	public class User /*: IdentityUser*/
	{
		public string FullName { get; set; }
		public bool IsActive { get; set; } = true;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Gender Gender { get; set; }
		public string UniversityName { get; set; }

		public string Nationality { get; set; }

        public bool IsGraduated { get; set; }


    }
}
