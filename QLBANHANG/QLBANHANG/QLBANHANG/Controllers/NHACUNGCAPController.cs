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
    public class NHACUNGCAPController : Controller
    {
        private QLBH db = new QLBH();

        // GET: NHACUNGCAP
        public ActionResult Index()
        {
            return View(db.NHACUNGCAP.ToList());
        }

        // GET: NHACUNGCAP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAP.Find(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // GET: NHACUNGCAP/Create
        public ActionResult Create()
        {
            ViewBag.Check = 0;
            return View();
        }

        // POST: NHACUNGCAP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANCC,TENNCC,DIACHI,SDT,EMAIL,FAX")] NHACUNGCAP nHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                var listMANCC = from l in db.NHACUNGCAP select l.MANCC;
                if (listMANCC.Contains(nHACUNGCAP.MANCC))
                {
                    ViewBag.Check = 1;
                    ViewBag.Error = "Không được nhập khóa giống nhau";
                    return View();
                }
                else
                {
                    db.NHACUNGCAP.Add(nHACUNGCAP);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(nHACUNGCAP);
        }

        // GET: NHACUNGCAP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAP.Find(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // POST: NHACUNGCAP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANCC,TENNCC,DIACHI,SDT,EMAIL,FAX")] NHACUNGCAP nHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHACUNGCAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHACUNGCAP);
        }

        // GET: NHACUNGCAP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAP.Find(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // POST: NHACUNGCAP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAP.Find(id);
            var maNCC = from c in db.CHITIETNHACUNGCAP select c.MANCC;
            if (maNCC.Contains(id))
            {
                ViewBag.Check = 1;
                ViewBag.Error = "Xóa các chi tiết nhà cung cấp liên quan đến nhà cung cấp này";
                return View(nHACUNGCAP);
            }
            else
            {
                db.NHACUNGCAP.Remove(nHACUNGCAP);
                db.SaveChanges();
            }
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
