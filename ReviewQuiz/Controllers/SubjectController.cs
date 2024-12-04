using ReviewQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewQuiz.Controllers
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
            var model = new List<Student>()
            {
                new Student("SOT335", "Lập trình Web", 3),
                new Student("NEC320", "Mạng máy tính", 2)
            };
            return View(model);
        }
    }
}