using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBANHANG.Models;

namespace QLBANHANG.Controllers
{
    public class MATHANGController : Controller
    {
        private QLBH db = new QLBH();

        // GET: MATHANG
        public ActionResult Index()
        {
            var mATHANG = db.MATHANG.Include(m => m.LOAIMATHANG);
            return View(mATHANG.ToList());
        }

        // GET: MATHANG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATHANG mATHANG = db.MATHANG.Find(id);
            if (mATHANG == null)
            {
                return HttpNotFound();
            }
            return View(mATHANG);
        }

        // GET: MATHANG/Create
        public ActionResult Create()
        {
            ViewBag.MALMH = new SelectList(db.LOAIMATHANG, "MALMH", "TENLMH");
            return View();
        }

        // POST: MATHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAMH,MALMH,TENMH,SOLUONGTK,VITRI,MOTA,GIABAN,GIAMUA,DONVI")] MATHANG mATHANG)
        {
            if (ModelState.IsValid)
            {
                var listMAMH = from l in db.MATHANG select l.MAMH;
                if (listMAMH.Contains(mATHANG.MAMH))
                {
                    ViewBag.Check = 1;
                    ViewBag.Error = "Không được nhập khóa giống nhau";
                    ViewBag.MALMH = new SelectList(db.LOAIMATHANG, "MALMH", "TENLMH", mATHANG.MALMH);
                    return View();
                }
                else
                {
                    db.MATHANG.Add(mATHANG);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.MALMH = new SelectList(db.LOAIMATHANG, "MALMH", "TENLMH", mATHANG.MALMH);
            return View(mATHANG);
        }

        // GET: MATHANG/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATHANG mATHANG = db.MATHANG.Find(id);
            if (mATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALMH = new SelectList(db.LOAIMATHANG, "MALMH", "TENLMH", mATHANG.MALMH);
            return View(mATHANG);
        }

        // POST: MATHANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAMH,MALMH,TENMH,SOLUONGTK,VITRI,MOTA,GIABAN,GIAMUA,DONVI")] MATHANG mATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MALMH = new SelectList(db.LOAIMATHANG, "MALMH", "TENLMH", mATHANG.MALMH);
            return View(mATHANG);
        }

        // GET: MATHANG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATHANG mATHANG = db.MATHANG.Find(id);
            if (mATHANG == null)
            {
                return HttpNotFound();
            }
            return View(mATHANG);
        }

        // POST: MATHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MATHANG mATHANG = db.MATHANG.Find(id);
            var maMH1 = from mct in db.CHITIETDONNHAPHANG select mct.MAMH;
            var maMH2 = from mct in db.CHITIETHOADON select mct.MAMH;
            var maMH3 = from mct in db.CHITIETNHACUNGCAP select mct.MAMH;
            if (maMH1.Contains(id) || maMH2.Contains(id) || maMH3.Contains(id))
            {
                ViewBag.Check = 1;
                ViewBag.Error = "Xóa các chi tiết nhà cung cấp hoặc đơn nhập hàng hoặc phiếu thanh toán liên quan đến mặt hàng này";
                return View();
            }
            db.MATHANG.Remove(mATHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
