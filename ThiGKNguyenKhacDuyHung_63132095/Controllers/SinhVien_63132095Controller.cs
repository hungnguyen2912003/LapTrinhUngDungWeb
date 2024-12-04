using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ThiGKNguyenKhacDuyHung_63132095.Models;

namespace ThiGKNguyenKhacDuyHung_63132095.Controllers
{
    public class SinhVien_63132095Controller : Controller
    {
        //Giới thiệu
        public ActionResult Introduction_63132095()
        {
            return View();
        }
        //Danh sách
        public ActionResult List()
        {
            ThiGK_63132095Entities qls = new ThiGK_63132095Entities();
            return View(qls.Sach.ToList());
        }

        //Thêm mới
        public ActionResult Create()
        {
            ThiGK_63132095Entities qls = new ThiGK_63132095Entities();
            List<Loaisach> loaisach = qls.Loaisach.ToList();
            SelectList ls = new SelectList(loaisach, "maloaisach", "tenloaisach");
            ViewBag.SachList = ls;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sach sach, HttpPostedFileBase ImgFile)
        {
            if (ModelState.IsValid)
            {
                ThiGK_63132095Entities qls = new ThiGK_63132095Entities();
                List<Loaisach> loaisach = qls.Loaisach.ToList();
                SelectList ls = new SelectList(loaisach, "maloaisach", "tenloaisach");
                ViewBag.SachList = ls;
                if (ImgFile != null && ImgFile.ContentLength > 0)
                {
                    string saveFile = Server.MapPath("/Images/");
                    string path = saveFile + ImgFile.FileName;
                    ImgFile.SaveAs(path);
                    sach.anhbia = "/Images/" + ImgFile.FileName;
                }
                qls.Sach.Add(sach);
                qls.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ThiGK_63132095Entities qls = new ThiGK_63132095Entities();
                List<Loaisach> loaisach = qls.Loaisach.ToList();
                SelectList ls = new SelectList(loaisach, "maloaisach", "tenloaisach");
                ViewBag.SachList = ls;
                return View(sach);
            }
        }
        //Chi tiết
        public ActionResult Details(string id)
        {
            ThiGK_63132095Entities qls = new ThiGK_63132095Entities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = qls.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        //Tìm kiếm
        public ActionResult Filter(string name)
        {
            ThiGK_63132095Entities qls = new ThiGK_63132095Entities();
            var sach = qls.Sach.ToList();
            if (!string.IsNullOrEmpty(name))
            {
                List<Sach> ls = qls.Sach.Where(model => model.tensach.ToLower().Contains(name)).ToList();
                return View(ls);
            }
            else
                return View(sach);
        }
    }
}
