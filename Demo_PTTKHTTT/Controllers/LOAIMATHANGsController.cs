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
    public class LOAIMATHANGsController : Controller
    {
        private Demo_QLBHEntities db = new Demo_QLBHEntities();

        // GET: LOAIMATHANGs
        public ActionResult Index()
        {
            return View(db.LOAIMATHANG.ToList());
        }

        // GET: LOAIMATHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMATHANG lOAIMATHANG = db.LOAIMATHANG.Find(id);
            if (lOAIMATHANG == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMATHANG);
        }

        // GET: LOAIMATHANGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAIMATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALMH,TENLMH")] LOAIMATHANG lOAIMATHANG)
        {
            if (ModelState.IsValid)
            {
                db.LOAIMATHANG.Add(lOAIMATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIMATHANG);
        }

        // GET: LOAIMATHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMATHANG lOAIMATHANG = db.LOAIMATHANG.Find(id);
            if (lOAIMATHANG == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMATHANG);
        }

        // POST: LOAIMATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALMH,TENLMH")] LOAIMATHANG lOAIMATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIMATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIMATHANG);
        }

        // GET: LOAIMATHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMATHANG lOAIMATHANG = db.LOAIMATHANG.Find(id);
            if (lOAIMATHANG == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMATHANG);
        }

        // POST: LOAIMATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAIMATHANG lOAIMATHANG = db.LOAIMATHANG.Find(id);
            db.LOAIMATHANG.Remove(lOAIMATHANG);
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
