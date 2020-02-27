using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class TestXQuestion
	{
		public TestXQuestion()
		{
			this.TestXPapers = new HashSet<TestXPaper>();
			this.QuestionXDurations = new HashSet<QuestionXDuration>();
		}
		public int TestXQuestionId { get; set; }
		public int QuestionNumber { get; set; }
		public bool IsActive { get; set; }

		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }

		public int TestId { get; set; }
		public virtual Test Test { get; set; }

		public virtual ICollection<TestXPaper> TestXPapers { get; set; }
		public virtual ICollection<QuestionXDuration> QuestionXDurations { get; set; }

	}
}