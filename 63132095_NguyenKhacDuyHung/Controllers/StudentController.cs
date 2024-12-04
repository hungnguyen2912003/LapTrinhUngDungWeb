using _63132095_NguyenKhacDuyHung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _63132095_NguyenKhacDuyHung.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult StdList(int id)
		{
			var ls = new List<Student>()
			{
				new Student(1, "Hưng Nguyễn", "63CNTT4", "/Images/student1.jpg"),
				new Student(2, "Phạm Sơn", "63CNTT2", "/Images/student2.JPG"),
				new Student(3, "Ánh Tuyết", "63CNTT3", "/Images/student3.jpeg"),
				new Student(4, "Nguyệt Phạm", "63CNTT5", "/Images/student4.jpeg"),
				new Student(5, "Anh Vũ", "63CNTT1", "/Images/student5.jpeg")
			};
			foreach (var s in ls)
			{
				if (s.Id == id)
				{
					ViewBag.Check = "1";
					ViewBag.Student = s;
					return View();
				}
			}
			ViewBag.Check = "0";
			ViewBag.Student = id;
			return View();

		}
    }
}