using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class Exhibit
	{
		public Exhibit()
		{
			this.Questions = new HashSet<Question>();
		}
		public int ExhibitId { get; set; }

		public virtual ICollection<Question> Questions { get; set; }
	}
}