using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public class QuizOnlineDBEntities : DbContext
	{
		public QuizOnlineDBEntities() : base("name=QuizOnlineDBEntities")
		{
		}

		public virtual DbSet<Choice> Choice { get; set; }
		public virtual DbSet<Exhibit> Exhibit { get; set; }
		public virtual DbSet<Question> Question { get; set; }
		public virtual DbSet<QuestionCategory> QuestionCategory { get; set; }
		public virtual DbSet<QuestionXDuration> QuestionXDuration { get; set; }
		public virtual DbSet<Registration> Registration { get; set; }
		public virtual DbSet<Student> Student { get; set; }
		public virtual DbSet<Test> Test { get; set; }
		public virtual DbSet<TestXPaper> TestXPaper { get; set; }
		public virtual DbSet<TestXQuestion> TestXQuestion { get; set; }

	}
}