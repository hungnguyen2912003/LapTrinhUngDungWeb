using BTT3_Nhom9_63CNTT4.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTT3_Nhom9_63CNTT4.Controllers
{
    public class PTB1Controller : Controller
    {
        // GET: PTB1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult File()
        {
            return View();
        }
        public ActionResult Helper()
        {
            return View();
        }
        public ActionResult StronglyHelper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StronglyHelper(double a, double b)
        {
            if (a == 0 && b == 0)
            {
                ViewBag.KQ = "Phương trình vô số nghiệm";
            }
            else if (a == 0) ViewBag.KQ = "Phuơng trình vô nghiệm";
            else ViewBag.KQ = -b / a;
            return View();
        }
    }
}