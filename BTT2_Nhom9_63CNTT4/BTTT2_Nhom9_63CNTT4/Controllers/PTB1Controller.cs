using BTTT2_Nhom9_63CNTT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTTT2_Nhom9_63CNTT4.Controllers
{
    public class PTB1Controller : Controller
    {
        // GET: PTB1
        public ActionResult Interface()
        {
            return View();
        }
		//Sử dụng Request
		public ActionResult UseRequest()
		{
			return View();
		}
		[HttpPost]
		public ActionResult UseRequest(string kq)
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
		//Sử dụng đối số (Arguments)
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
		//Sử dụng FormCollection
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
		//Sử dụng Model
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