﻿using BTT3_Nhom9_63CNTT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTT3_Nhom9_63CNTT4.Controllers
{
	public class EmployeeController : Controller
	{
		// GET: Employee
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(HttpPostedFileBase Avatar, EmpModel emp)
		{
			//Lấy thông tin từ input type=file có tên Avatar
			string postedFileName = System.IO.Path.GetFileName(Avatar.FileName);
			//Lưu hình đại diện về Server
			var path = Server.MapPath("/Images/" + postedFileName);
			Avatar.SaveAs(path);
			string fSave = Server.MapPath("/App_Data/emp.txt");
			string[] emInfo ={emp.EmpID, emp.Name, postedFileName};
			//Lưu các thông tix vào tập tin emp.txt
			System.IO.File.WriteAllLines(fSave, emInfo);
			//Ghi nhận các thông tin đăng ký để hiện thị trên View Confirm
			ViewBag.EmpID = emInfo[0];
			ViewBag.Name = emInfo[1];
			ViewBag.Avatar = "/Images/" + emInfo[2];
			return View("Confirm");
		}
		public ActionResult Confirm(EmpModel emp)
		{
			return View();
		}
	}
}