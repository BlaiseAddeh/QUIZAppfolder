using OnlineExamSystem.Models;
using OnlineExamSystem.Models.ManageFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamSystem.Controllers
{
	public class HomeController : Controller
	{
		QuizOnlineDBEntities _db = new QuizOnlineDBEntities();

		
		public ActionResult Index()
		{
			ViewBag.Tests = _db.Test.Where(x => x.IsActive == true).Select(x => new { x.TestId, x.Name }).ToList();

			SessionModel _model = null;

			if (Session["SessionModel"] == null)
				_model = new SessionModel();
			else
				_model = (SessionModel)Session["SessionModel"];
			
			
			return View(_model);
		}

		
		public ActionResult Instruction(SessionModel model)
		{
			if (model !=null)
			{
				var test = _db.Test.Where(x => x.IsActive == true && x.TestId == model.TestId).FirstOrDefault();

				if (test != null)
				{
					ViewBag.TestName = test.Name;
					ViewBag.TestDescription = test.Description;
					ViewBag.QuestionCount = test.TestXQuestions.Count();
					ViewBag.TestDuration = test.DurationInMinute;
				}

			}
			return View(model);
		}

		public ActionResult Register(SessionModel model)
		{
			if (model != null)
				Session["SessionModel"] = model;
					

			if(model == null || string.IsNullOrEmpty(model.UserName) || model.TestId < 1)
			{
				TempData["message"] = "Invalid Registration details. Please try again";
				return RedirectToAction("Index");
			}

			//To register the user to the system
			//To register the user for test

			Student _user = _db.Student
							.Where(x => x.Name.Equals(model.UserName, StringComparison.InvariantCultureIgnoreCase)
							&& ((string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(x.Email)) || 
							     (x.Email == model.Email))
							&& ((string.IsNullOrEmpty(model.Phone) && string.IsNullOrEmpty(x.Phone)) || 
							     (x.Phone == model.Phone))).FirstOrDefault();

			if (_user == null)
			{
				_user = new Student()
				{
					Name = model.UserName,
					Email = model.Email,
					Phone = model.Phone,
					EntryDate = DateTime.UtcNow,
					AccessLevel = 100
				};

				_db.Student.Add(_user);
				_db.SaveChanges();

			}

			Registration registration = _db.Registration.Where(x => x.StudentId == _user.StudentId
										&& x.TestId == model.TestId
										&& x.TokenExpireTime > DateTime.UtcNow).FirstOrDefault();

			if (registration !=null)
			{
				this.Session["TOKEN"] = registration.Token;
				this.Session["TOKENEXPIRE"] = registration.TokenExpireTime;
			}
			else
			{
				Test test = _db.Test.Where(x => x.IsActive && x.TestId == model.TestId).FirstOrDefault();
				if (test !=null)
				{
					Registration newRegistration = new Registration()
					{
						RegistrationDate = DateTime.UtcNow,
						TestId = model.TestId,
						Token = Guid.NewGuid().ToString(),
						TokenExpireTime = DateTime.UtcNow.AddMinutes(test.DurationInMinute)
					};

					_user.Registrations.Add(newRegistration);
					_db.Registration.Add(newRegistration);
					_db.SaveChanges();

					this.Session["TOKEN"] = newRegistration.Token;
					this.Session["TOKENEXPIRE"] = newRegistration.TokenExpireTime;

				}
			}



			return View("EvalPage", new { @token = Session["TOKEN"]});
		}

		public ActionResult EvalPage(Guid token, int? qno)
		{
			if (token == null)
			{
				TempData["message"] = "You have an invalid token.Please re-register and try again";
				return RedirectToAction("Index");
			}

			// Verify the user is registered and is allow to check the question

			var registration = _db.Registration.Where(x => x.Token.Equals(token)).FirstOrDefault();

			if (registration == null)
			{
				TempData["message"] = "This token is invalid";
				return RedirectToAction("Index");
			}
			if (registration.TokenExpireTime < DateTime.UtcNow)
			{
				TempData["message"] = "The exam duration has expired at " + registration.TokenExpireTime.ToString();
				return RedirectToAction("Index");
			}

			if (qno.GetValueOrDefault() < 1)
				qno = 1;

			var testQuestionId = _db.TestXQuestion
				.Where(x => x.TestId == registration.TestId && x.QuestionNumber == qno)
				.Select(x => x.TestId).FirstOrDefault();

			if (testQuestionId > 0)
			{
				var _model = _db.TestXQuestion.Where(x => x.TestXQuestionId == testQuestionId).Select(x => new QuestionModel() { 
				QuestionType = x.Question.QuestionType,
				QuestionNumber = x.QuestionNumber,
				Question = x.Question.Question1,
				Point = x.Question.Points,
				TestId = x.TestId,
				TestName = x.Test.Name,
				Options = x.Question.Choices.Where(y => y.IsActive == true).Select(y => new QXOModel()
				{
					ChoiceId = y.Id,
					Label = y.Label
				}).ToList()
				}).FirstOrDefault();

				return View(_model);
			}
			else
			{
				return View("Error");
			}
		}


	}
}