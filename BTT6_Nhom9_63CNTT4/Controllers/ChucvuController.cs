using BTT6_Nhom9_63CNTT4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BTT6_Nhom9_63CNTT4.Controllers
{
    public class ChucvuController : Controller
    {
        //Hiển thị danh sách chức vụ
        public ActionResult Index()
        {
            DBContext qlnv = new DBContext();
            return View(qlnv.Chucvus.ToList());
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Chucvu cv)
        {
            DBContext qlnv = new DBContext();
            if (qlnv.Chucvus.Any(model => model.MaCV == cv.MaCV))
            {
                ModelState.AddModelError("MaCV", "Mã chức vụ đã tồn tại!");
            }
            if (ModelState.IsValid)
            {
                qlnv.Chucvus.Add(cv);
                qlnv.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cv);
        }

        //Edit
        public ActionResult Edit(string id)
        {
            DBContext qlnv = new DBContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chucvu cv = qlnv.Chucvus.Find(id);
            if (cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }

        [HttpPost]
        public ActionResult Edit(Chucvu cv)
        {
            DBContext qlnv = new DBContext();
            if (ModelState.IsValid)
            {
                qlnv.Entry(cv).State = EntityState.Modified;
                qlnv.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cv);
        }

        //Delete
        public ActionResult Delete(string id)
        {
            DBContext qlnv = new DBContext();
            Chucvu cv = qlnv.Chucvus.Find(id);
            qlnv.Chucvus.Remove(cv);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}