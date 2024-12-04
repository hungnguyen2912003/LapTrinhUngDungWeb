using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai4_Bonus.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var model = new List<Bai4_Bonus.Models.Subject>()
            {
                new Models.Subject("SOT335", "Huớng đối tượng", 3),
                new Models.Subject("NEC325", "Mạng máy tính", 3)
            };
            return View(model);
        }
    }
}