using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class Student
	{
		public Student()
		{
			this.Registrations = new HashSet<Registration>();
		}
		public int StudentId { get; set; }
		public string Name { get; set; }
		public string AccessLevel { get; set; }
		public DateTime EntryDate { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string PassHash { get; set; }

		public virtual ICollection<Registration> Registrations { get; set; }
	}
}