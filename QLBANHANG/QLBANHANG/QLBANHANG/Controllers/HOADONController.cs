using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBANHANG.Models;

namespace QLBANHANG.Controllers
{
    public class HOADONController : Controller
    {
        private QLBH db = new QLBH();

        // GET: HOADON
        public ActionResult Index()
        {
            foreach(var hd in db.HOADON)
            {
                hd.tongtienhd = db.CHITIETHOADON.Where(m => m.MAHD == hd.MAHD).Sum(m => m.SOLUONGMH * m.MATHANG.GIABAN);
            }
            return View(db.HOADON.ToList());
        }


        public ActionResult Details(string mahd)
        {
            if (mahd == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADON.Find(mahd);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            var cthd = db.CHITIETHOADON.Where(m => m.MAHD == mahd);
            foreach (var ct in cthd)
            {
                ct.thanhtien = ct.MATHANG.GIABAN * ct.SOLUONGMH;
            }
            hOADON.tongtienhd = cthd.Sum(m => m.SOLUONGMH * m.MATHANG.GIABAN);
            var ngayLap = db.HOADON.Where(m => m.MAHD == mahd).Select(m => m.NGAYLAPHD).FirstOrDefault();
            ViewBag.Mahd = db.HOADON.Where(m => m.MAHD == mahd).Select(m => m.MAHD).FirstOrDefault();
            ViewBag.Ngaylap =  String.Format("{0:dd/MM/yyyy}", ngayLap);
            ViewBag.Tongtien = String.Format("{0:C0}", hOADON.tongtienhd);
            return View(cthd.ToList());
        }
        public ActionResult Delete(string mahd)
        {
            if (mahd == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADON.Find(mahd);
            if (hOADON == null)
                return HttpNotFound();
            {
            }
            var cthd = db.CHITIETHOADON.Where(m => m.MAHD == mahd);
            foreach (var ct in cthd)
            {
                ct.thanhtien = ct.MATHANG.GIABAN * ct.SOLUONGMH;
            }
            hOADON.tongtienhd = cthd.Sum(m => m.SOLUONGMH * m.MATHANG.GIABAN);
            var ngayLap = db.HOADON.Where(m => m.MAHD == mahd).Select(m => m.NGAYLAPHD).FirstOrDefault();
            ViewBag.Mahd = db.HOADON.Where(m => m.MAHD == mahd).Select(m => m.MAHD).FirstOrDefault();
            ViewBag.Ngaylap = String.Format("{0:dd/MM/yyyy}", ngayLap);
            ViewBag.Tongtien = String.Format("{0:C0}", hOADON.tongtienhd);
            return View(cthd.ToList());
        }

        // POST: HOADON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string mahd)
        {
            HOADON hOADON = db.HOADON.Find(mahd);
            var cthd = db.CHITIETHOADON.Where(m => m.MAHD == mahd);
            foreach ( var ct in cthd)
            {
                db.CHITIETHOADON.Remove(ct);
            }
            db.HOADON.Remove(hOADON);
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
