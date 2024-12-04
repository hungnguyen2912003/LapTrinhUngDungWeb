using BTT3_Nhom9_63CNTT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTT3_Nhom9_63CNTT4.Controllers
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
		public ActionResult Greeting()
		{
			ViewBag.Message = "Xin chào các bạn 63CNTT4";
			return View();
		}
		public ActionResult Cal()
		{
			return View();
		}
	}
}