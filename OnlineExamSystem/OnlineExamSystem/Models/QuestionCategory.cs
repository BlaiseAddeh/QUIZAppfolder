using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class QuestionCategory
	{
		public QuestionCategory()
		{
			this.Questions = new HashSet<Question>();
		}
		public int QuestionCategoryId { get; set; }
		public string Category { get; set; }

		public virtual ICollection<Question> Questions { get; set; }
	}
}