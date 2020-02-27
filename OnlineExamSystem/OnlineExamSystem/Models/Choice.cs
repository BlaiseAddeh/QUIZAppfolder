using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class Choice
	{
		public Choice()
		{
			this.TestXPapers = new HashSet<TestXPaper>();
		}
		public int Id { get; set; }
		public string Label { get; set; }
		public int Points { get; set; }
		public bool IsActive { get; set; }

		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }

		public virtual ICollection<TestXPaper> TestXPapers { get; set; }
	}
}