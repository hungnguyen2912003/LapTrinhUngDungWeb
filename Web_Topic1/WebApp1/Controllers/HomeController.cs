using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
	public class HomeController : Controller
	{
		/*Ví dụ 1*/
		public string Index(string id)
		{
			return ("Chào các bạn lớp " + id);
		}
		/*Ví dụ 2*/
		//greeting
		public ActionResult Greeting()
		{
			return View();
		}
		//list
		/*Ví dụ 3*/
		public ActionResult list()
		{
			var model = new List<Student>(){
				new Student("Phạm Văn An", "63.CNTT4"),
				new Student("Võ Minh Sơn", "63.CNTT5"),
				new Student("Nguyễn Hoàng Sơn", "63.CNTT1")
			};
			return View(model);
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