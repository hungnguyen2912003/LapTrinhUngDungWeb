using ReviewQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewQuiz.Controllers
{
	public class HomeController : Controller
	{
		public string IndexStudent(string id)
		{
			return ("Chào các bạn lớp " + id);
		}
		public ActionResult Index()
		{
			return View();
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
		public ActionResult Greeting()
		{
			return View();
		}
		public ActionResult ListStudent()
		{
			var model = new List<Student>()
			{
				new Student("Hưng Nguyễn", "63CNTT4"),
				new Student("Lan Huỳnh", "63CNTT3"),
				new Student("Quỳnh Đặng", "63CNTT2"),
				new Student("Ngô Liên", "63CNTT5"),
				new Student("Võ Minh Sơn", "63CNTT1"),
				new Student("Cao Bá Lầu", "63CNTT2"),
			};
			return View(model);
		}
	}
}