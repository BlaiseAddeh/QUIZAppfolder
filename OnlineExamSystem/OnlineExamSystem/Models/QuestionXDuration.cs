using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
	public partial class QuestionXDuration
	{
		public int QuestionXDurationId { get; set; }
		public string RquestTime { get; set; }
		public string LeaveTime { get; set; }
		public string AnsweredTime { get; set; }

		public int RegistrationId { get; set; }
		public virtual Registration Registration { get; set; }

		public int TestXQuestionId { get; set; }
		public virtual TestXQuestion TestXQuestion { get; set; }

	}
}