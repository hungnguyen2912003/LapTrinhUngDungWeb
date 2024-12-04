using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewExample.Models;

namespace ViewExample.Controllers
{
	public class HomeController : Controller
	{
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

		public ActionResult Hello()
		{
			ViewBag.Greeting = "Chao tat ca cac lop";
			ViewData["class"] = "63CNTT4";
			return View();
		}
	}
}