using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class Test
	{
		public Test()
		{
			this.Registrations = new HashSet<Registration>();
			this.TestXQuestions = new HashSet<TestXQuestion>();
		}
		[Key]
		public int TestId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public String DurationInMinute { get; set; }

		
		public virtual ICollection<Registration> Registrations { get; set; }
		public virtual ICollection<TestXQuestion> TestXQuestions { get; set; }

	}
}