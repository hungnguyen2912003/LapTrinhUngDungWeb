using BTT3_Nhom9_63CNTT4.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTT3_Nhom9_63CNTT4.Controllers
{
    public class StudentController : Controller
    {
		// GET: Student
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Index(HttpPostedFileBase Images, Student s)
		{
			//Lấy thông tin từ input type=file có tên Avatar
			string postedFileName = System.IO.Path.GetFileName(Images.FileName);
			//Lưu hình đại diện về Server
			var path = Server.MapPath("/Images/" + postedFileName);
			Images.SaveAs(path);
			string fSave = Server.MapPath("/App_Data/std.txt");
			string[] stuInfo ={s.Id, s.Name, postedFileName};
			//Lưu các thông tix vào tập tin emp.txt
			System.IO.File.WriteAllLines(fSave, stuInfo);
			//Ghi nhận các thông tin đăng ký để hiện thị trên View Confirm
			ViewBag.StudentID = stuInfo[0];
			ViewBag.StudentName = stuInfo[1];
			ViewBag.Avatar = "/Images/" + stuInfo[2];
			return View("Confirm");
		}
		public ActionResult Confirm(Student s)
		{
			return View();
		}
	}
}