using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class Registration
	{
		public Registration()
		{
			this.QuestionXDurations = new HashSet<QuestionXDuration>();
			this.TestXPapers = new HashSet<TestXPaper>();
		}

		public int RegistrationId { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string Token { get; set; }
		public DateTime TokenExpireTime { get; set; }

		public int StudentId { get; set; }
		public virtual Student Student { get; set; }

		public int TestId { get; set; }
		public virtual Test Test { get; set; }

		public virtual ICollection<QuestionXDuration> QuestionXDurations { get; set; }
		public virtual ICollection<TestXPaper> TestXPapers { get; set; }
	}
}