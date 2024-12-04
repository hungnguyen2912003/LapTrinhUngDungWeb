using SampleStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace SampleStudent.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ContentResult FindName(int id)
        {
			var ls = new List<Student>()
			{
				new Student(1, "Võ Minh Sơn", "63CNTT5"),
				new Student(2, "Nguyễn Văn An", "63CNTT4"),
				new Student(3, "Phạm Minh Thành", "63CNTT1"),
				new Student(4, "Nguyễn Trọng Tín", "63CNTT3")
			};

            foreach (var s in ls)
            {
                if(s.Id == id)
                {
                    return Content(s.Name);
                }
            }
            return Content("Không có sinh viên nào có ID trên");
		}
        public string Index()
        {
            return ("Chao cac ban");
        }

        public ActionResult FindSV(int id)
        {
            var ls = new List<Student>()
            {
                new Student(1, "Võ Minh Sơn", "63CNTT5"),
                new Student(2, "Nguyễn Văn An", "63CNTT4"),
                new Student(3, "Phạm Minh Thành", "63CNTT1"),
                new Student(4, "Nguyễn Trọng Tín", "63CNTT3")
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
        public ActionResult List()
        {
			var ls = new List<Student>()
			{
				new Student(1, "Võ Minh Sơn", "63CNTT5"),
				new Student(2, "Nguyễn Văn An", "63CNTT4"),
				new Student(3, "Phạm Minh Thành", "63CNTT1"),
				new Student(4, "Nguyễn Trọng Tín", "63CNTT3")
			};
            ViewBag.Student = ls;
            return View(ls);
		}
        public ActionResult ViewBag2List()
        {
			var stu = new List<Student>()
			{
				new Student(1, "Võ Minh Sơn", "63CNTT5"),
				new Student(2, "Nguyễn Văn An", "63CNTT4"),
				new Student(3, "Phạm Minh Thành", "63CNTT1"),
				new Student(4, "Nguyễn Trọng Tín", "63CNTT3"),
				new Student(5, "Phan Văn A", "63CNTT4"),
				new Student(6, "Trần Anh Thư", "63CNTT2"),
				new Student(7, "Đinh Phan Linh", "63CNTT4"),
				new Student(8, "Lê Minh Trí", "63CNTT4")
			};
            ViewBag.Student = stu;
			var stu2 = new List<Student>();
			foreach (var s in stu)
			{
				if (s.Class == "63CNTT4")
				{
					stu2.Add(s);
				}
			}
			ViewBag.Student2 = stu2;
			return View();
		}

		public ActionResult ViewBag2ListModel()
		{
			var stu = new List<Student>()
			{
				new Student(1, "Võ Minh Sơn", "63CNTT5"),
				new Student(2, "Nguyễn Văn An", "63CNTT4"),
				new Student(3, "Phạm Minh Thành", "63CNTT1"),
				new Student(4, "Nguyễn Trọng Tín", "63CNTT3"),
				new Student(5, "Phan Văn A", "63CNTT4"),
				new Student(6, "Trần Anh Thư", "63CNTT2"),
				new Student(7, "Đinh Phan Linh", "63CNTT4"),
				new Student(8, "Lê Minh Trí", "63CNTT4")
			};
			var stu2 = new List<Student>();
			foreach (var s in stu)
			{
				if (s.Class == "63CNTT4")
				{
					stu2.Add(s);
				}
			}
			var model = new Student
			{
				stud = stu,
				studclass = stu2
			};
			return View(model);
		}
    }
}