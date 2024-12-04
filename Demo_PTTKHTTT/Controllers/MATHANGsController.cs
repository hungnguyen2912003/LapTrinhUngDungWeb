using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_PTTKHTTT.Models;

namespace Demo_PTTKHTTT.Controllers
{
    public class MATHANGsController : Controller
    {
        private Demo_QLBHEntities db = new Demo_QLBHEntities();

        // GET: MATHANGs
        public ActionResult Index()
        {
            var mATHANG = db.MATHANG.Include(m => m.LOAIMATHANG);
            return View(mATHANG.ToList());
        }

        // GET: MATHANGs/Details/5
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

        // GET: MATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MALMH = new SelectList(db.LOAIMATHANG, "MALMH", "TENLMH");
            return View();
        }

        // POST: MATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAMH,MALMH,TENMH,SOLUONGTK,VITRI,MOTA,GIABAN,GIAMUA")] MATHANG mATHANG)
        {
            if (ModelState.IsValid)
            {
                db.MATHANG.Add(mATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MALMH = new SelectList(db.LOAIMATHANG, "MALMH", "TENLMH", mATHANG.MALMH);
            return View(mATHANG);
        }

        // GET: MATHANGs/Edit/5
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

        // POST: MATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAMH,MALMH,TENMH,SOLUONGTK,VITRI,MOTA,GIABAN,GIAMUA")] MATHANG mATHANG)
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

        // GET: MATHANGs/Delete/5
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

        // POST: MATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MATHANG mATHANG = db.MATHANG.Find(id);
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
