using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        /*Bài 4*/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var model = new List<Subject>()
            {
                new Subject ("SOT355", "Lập trình ứng dụng Web", 3),
                new Subject("SOT331", "Lập trình hướng đối tượng", 3),
                new Subject("INS339", "Hệ quản trị cơ sở dữ liệu", 3),
                new Subject("NEC329", "Mạng máy tính", 3),
                new Subject("INS360", "Phân tích thiết kế hệ thống thông tin", 3),
                new Subject("INS325", "Hệ điều hành", 3)
            };
            return View(model);
        }
    }
}