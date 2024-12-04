using SampleStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleStudent.Controllers
{
    public class PTB1Controller : Controller
    {
		// GET: PTB1
		public ActionResult Interface()
		{
			return View();
		}
		public ActionResult UseRequest2()
		{
			return View();
		}
		[HttpPost]
		public ActionResult UseRequest2(string kq)
		{
			double a = double.Parse(Request["a"]);
			double b = double.Parse(Request["b"]);
			if (a == 0)
				if (b == 0)
				{
					ViewBag.KQ = ("Phuong trinh vo so nghiem");
				}
				else
				{
					ViewBag.KQ = ("Phuong trinh vo nghiem");
				}
			else
			{
				ViewBag.KQ = -b / a;
			}
			return View();
		}
		public ActionResult UseArguments()
		{
			return View();
		}
		[HttpPost]
		public ActionResult UseArguments(double a, double b, string kq)
		{
			if (a == 0)
				if (b == 0)
				{
					ViewBag.KQ = ("Phuong trinh vo so nghiem");
				}
				else
				{
					ViewBag.KQ = ("Phuong trinh vo nghiem");
				}
			else
			{
				ViewBag.KQ = -b / a;
			}
			return View();
		}

		public ActionResult UseFormCollection()
		{
			return View();
		}
		[HttpPost]
		public ActionResult UseFormCollection(FormCollection f)
		{
			double a = double.Parse(f["a"]);
			double b = double.Parse(f["b"]);
			if (a == 0)
				if (b == 0)
				{
					ViewBag.KQ = ("Phuong trinh vo so nghiem");
				}
				else
				{
					ViewBag.KQ = ("Phuong trinh vo nghiem");
				}
			else
			{
				ViewBag.KQ = -b / a;
			}
			return View();
		}
		public ActionResult UseModel()
		{
			return View();
		}
		[HttpPost]
		public ActionResult UseModel(CalModel cal)
		{
			if (cal.a == 0)
				if (cal.b == 0)
				{
					ViewBag.KQ = ("Phuong trinh vo so nghiem");
				}
				else
				{
					ViewBag.KQ = ("Phuong trinh vo nghiem");
				}
			else
			{
				ViewBag.KQ = -cal.b / cal.a;
			}
			return View();
		}
	}
}