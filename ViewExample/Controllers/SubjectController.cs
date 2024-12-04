using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewExample.Models;

namespace ViewExample.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult ViewBagObj()
		{
			Subject sub = new Subject("SOT335", "Phát triển ứng dụng Web", 3);
			ViewBag.Subject = sub;
			return View();
		}
	}
}