using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class Question
	{
		public Question()
		{
			this.Choices = new HashSet<Choice>();
			this.TestXQuestions = new HashSet<TestXQuestion>();
		}
		public int QuestionId { get; set; }
		public string QuestionType { get; set; }
		public string Question1 { get; set; }
		public int Points { get; set; }
		public bool IsActive { get; set; }


		public int CategoryId { get; set; }
		public virtual QuestionCategory Category { get; set; }

		public int ExhibitId { get; set; }
		public virtual Exhibit Exhibit { get; set; }

		public virtual ICollection<Choice> Choices { get; set; }
		public virtual ICollection<TestXQuestion> TestXQuestions { get; set; }
	}
}