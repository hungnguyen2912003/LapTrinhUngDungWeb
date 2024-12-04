using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using QLBANHANG.Models;

namespace QLBANHANG.Controllers
{
    public class CHITIETDONNHAPHANGController : Controller
    {
        private QLBH db = new QLBH();
        private int check = 0;
        // GET: CHITIETDONNHAPHANG
        public ActionResult Index()
        {
            var cHITIETDONNHAPHANG = db.CHITIETDONNHAPHANG.Include(c => c.DONNHAPHANG).Include(c => c.MATHANG);
            return View(cHITIETDONNHAPHANG.ToList());
        }

        // GET: CHITIETDONNHAPHANG/Create
        public ActionResult Create()
        {
            ViewBag.MADNH = new SelectList(db.DONNHAPHANG, "MADNH", "MADNH");
            ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "TENMH");
            return View();
        }

        // POST: CHITIETDONNHAPHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAMH,MADNH,SOLUONGNH")] CHITIETDONNHAPHANG cHITIETDONNHAPHANG)
        {
            if (ModelState.IsValid)
            {
                var listMAMH = from l in db.CHITIETDONNHAPHANG where l.MADNH == cHITIETDONNHAPHANG.MADNH select l.MAMH;
                if (listMAMH.Contains(cHITIETDONNHAPHANG.MAMH))
                {
                    ViewBag.Check = 1;
                    ViewBag.Error = "Không được nhập khóa giống nhau";
                    ViewBag.MADNH = new SelectList(db.DONNHAPHANG, "MADNH", "MADNH", cHITIETDONNHAPHANG.MADNH);
                    ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "TENMH", cHITIETDONNHAPHANG.MAMH);
                    return View();
                }
                var dnh = db.DONNHAPHANG.Find(cHITIETDONNHAPHANG.MADNH);
                if(dnh.TRANGTHAI == true)
                {
                    ViewBag.Check = 1;
                    ViewBag.Error = "Đơn nhập hàng này đã được xác nhận";
                    ViewBag.MADNH = new SelectList(db.DONNHAPHANG, "MADNH", "MADNH", cHITIETDONNHAPHANG.MADNH);
                    ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "TENMH", cHITIETDONNHAPHANG.MAMH);
                    return View();
                }
                db.CHITIETDONNHAPHANG.Add(cHITIETDONNHAPHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MADNH = new SelectList(db.DONNHAPHANG, "MADNH", "MADNH", cHITIETDONNHAPHANG.MADNH);
            ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "TENMH", cHITIETDONNHAPHANG.MAMH);
            return View(cHITIETDONNHAPHANG);
        }

        // GET: CHITIETDONNHAPHANG/Edit/5
        public ActionResult Edit(string id1, string id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONNHAPHANG cHITIETDONNHAPHANG = db.CHITIETDONNHAPHANG.Find(id1, id2);
            if (cHITIETDONNHAPHANG == null)
            {
                return HttpNotFound();
            }
            if(cHITIETDONNHAPHANG.DONNHAPHANG.TRANGTHAI == true)
            {
                ViewBag.Check = 1;
                ViewBag.Error = "Đơn nhập hàng này đã được xác nhận nên không thể chỉnh sửa";
                var ctdnh = db.CHITIETDONNHAPHANG.Include(c => c.DONNHAPHANG).Include(c => c.MATHANG);
                return View("Index", ctdnh.ToList());
            }
            ViewBag.MADNH = new SelectList(db.DONNHAPHANG, "MADNH", "MADNH", cHITIETDONNHAPHANG.MADNH);
            ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "TENMH", cHITIETDONNHAPHANG.MAMH);
            return View(cHITIETDONNHAPHANG);
        }

        // POST: CHITIETDONNHAPHANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAMH,MADNH,SOLUONGNH")] CHITIETDONNHAPHANG cHITIETDONNHAPHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDONNHAPHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MADNH = new SelectList(db.DONNHAPHANG, "MADNH", "MADNH", cHITIETDONNHAPHANG.MADNH);
            ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "MH", cHITIETDONNHAPHANG.MAMH);
            return View(cHITIETDONNHAPHANG);
        }

        public ActionResult Delete(string id1, string id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONNHAPHANG cHITIETDONNHAPHANG = db.CHITIETDONNHAPHANG.Find(id1, id2);
            if (cHITIETDONNHAPHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONNHAPHANG);
        }

        // POST: CHITIETNHACUNGCAP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id1, string id2)
        {
            CHITIETDONNHAPHANG cHITIETDONNHAPHANG = db.CHITIETDONNHAPHANG.Find(id1, id2);
            db.CHITIETDONNHAPHANG.Remove(cHITIETDONNHAPHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: CHITIETDONNHAPHANG/Delete/5

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
