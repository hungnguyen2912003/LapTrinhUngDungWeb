using BTT4_Nhom9_63CNTT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTT4_Nhom9_63CNTT4.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Avatar, StudentModel stu)
        {
            string posted = System.IO.Path.GetFileName(Avatar.FileName);
            var path = Server.MapPath("/Images/" + posted);
            Avatar.SaveAs(path);
            string fSave = Server.MapPath("/App_Data/student.txt");
            string[] stuInfo ={stu.Id, stu.Name, stu.Class, posted};
            System.IO.File.WriteAllLines(fSave, stuInfo);
            ViewBag.StuID = stuInfo[0];
            ViewBag.StuName = stuInfo[1];
            ViewBag.StuClass = stuInfo[2];
            ViewBag.Avatar = "/Images/" + stuInfo[3];
            return View("Confirm");
        }
        public ActionResult Confirm(StudentModel std)
        {
            return View();
        }
    }
}