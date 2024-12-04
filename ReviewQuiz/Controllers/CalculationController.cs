using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewQuiz.Controllers
{
	public class CalculationController : Controller
	{   //Sử dụng Request
		public ActionResult UseRequest() { return View(); }
		[HttpPost]
		public ActionResult UseRequest(string pt)
		{
			double a = double.Parse(Request["a"]);//Chuyển đổi chuỗi sang số thực
			double b = double.Parse(Request["b"]); 
			pt = Request["pt"].ToString();
			switch (pt)
			{
				case "+": ViewBag.KQ = a + b; break;
				case "-": ViewBag.KQ = a - b; break;
				case "*": ViewBag.KQ = a * b; break;
				case "/":
					if (b == 0) ViewBag.KQ = "Không chia được cho 0"; else ViewBag.KQ = a / b; break;
			}
			return View();
		}
	}
}