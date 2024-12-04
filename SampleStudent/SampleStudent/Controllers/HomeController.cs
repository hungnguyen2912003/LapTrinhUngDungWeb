﻿using SampleStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleStudent.Controllers
{
	public class HomeController : Controller
	{
		public RedirectToRouteResult Index()
		{
			return RedirectToAction("Index", "Student");
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