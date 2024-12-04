using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBANHANG.Models;

namespace QLBANHANG.Controllers
{
    public class CHITIETNHACUNGCAPController : Controller
    {
        private QLBH db = new QLBH();

        // GET: CHITIETNHACUNGCAP
        public ActionResult Index()
        {
            var cHITIETNHACUNGCAP = db.CHITIETNHACUNGCAP.Include(c => c.NHACUNGCAP).Include(c => c.MATHANG);
            return View(cHITIETNHACUNGCAP.ToList());
        }

        // GET: CHITIETNHACUNGCAP/Details/5
        public ActionResult Details(string id1, string id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETNHACUNGCAP cHITIETNHACUNGCAP = db.CHITIETNHACUNGCAP.Find(id1, id2);
            if (cHITIETNHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETNHACUNGCAP);
        }

        // GET: CHITIETNHACUNGCAP/Create
        public ActionResult Create()
        {
            ViewBag.MANCC = new SelectList(db.NHACUNGCAP, "MANCC", "TENNCC");
            ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "TENMH");
            return View();
        }

        // POST: CHITIETNHACUNGCAP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAMH,MANCC,TENMATHANG,TENCC")] CHITIETNHACUNGCAP cHITIETNHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                var listMANCC = from l in db.CHITIETNHACUNGCAP select l.MANCC;
                var listMAMH = from l in db.CHITIETNHACUNGCAP select l.MAMH;
                if (listMANCC.Contains(cHITIETNHACUNGCAP.MANCC) && listMAMH.Contains(cHITIETNHACUNGCAP.MAMH))
                {
                    ViewBag.Check = 1;
                    ViewBag.Error = "Không được nhập khóa giống nhau";
                    ViewBag.MANCC = new SelectList(db.NHACUNGCAP, "MANCC", "TENNCC", cHITIETNHACUNGCAP.MANCC);
                    ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "TENMH", cHITIETNHACUNGCAP.MAMH);
                    return View();
                }
                db.CHITIETNHACUNGCAP.Add(cHITIETNHACUNGCAP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANCC = new SelectList(db.NHACUNGCAP, "MANCC", "TENNCC", cHITIETNHACUNGCAP.MANCC);
            ViewBag.MAMH = new SelectList(db.MATHANG, "MAMH", "TENMH", cHITIETNHACUNGCAP.MAMH);
            return View(cHITIETNHACUNGCAP);
        }

        // GET: CHITIETNHACUNGCAP/Delete/5
        public ActionResult Delete(string id1, string id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETNHACUNGCAP cHITIETNHACUNGCAP = db.CHITIETNHACUNGCAP.Find(id1, id2); 
            if(cHITIETNHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETNHACUNGCAP);
        }

        // POST: CHITIETNHACUNGCAP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id1, string id2)
        {
            CHITIETNHACUNGCAP cHITIETNHACUNGCAP = db.CHITIETNHACUNGCAP.Find(id1, id2);
            db.CHITIETNHACUNGCAP.Remove(cHITIETNHACUNGCAP);
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
