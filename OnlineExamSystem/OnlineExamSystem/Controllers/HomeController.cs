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

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}