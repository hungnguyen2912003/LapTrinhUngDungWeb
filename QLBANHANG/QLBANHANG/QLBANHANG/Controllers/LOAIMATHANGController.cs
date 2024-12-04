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
    public class LOAIMATHANGController : Controller
    {
        private QLBH db = new QLBH();

        // GET: LOAIMATHANG
        public ActionResult Index()
        {
            return View(db.LOAIMATHANG.ToList());
        }

        // GET: LOAIMATHANG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAIMATHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALMH,TENLMH")] LOAIMATHANG lOAIMATHANG)
        {
            if (ModelState.IsValid)
            {
                var listMALMH = from l in db.LOAIMATHANG select l.MALMH;
                if (listMALMH.Contains(lOAIMATHANG.MALMH))
                {
                    ViewBag.Check = 1;
                    ViewBag.Error = "Không được nhập khóa giống nhau";
                    return View();
                }
                else
                {
                    db.LOAIMATHANG.Add(lOAIMATHANG);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(lOAIMATHANG);
        }

        // GET: LOAIMATHANG/Edit/5
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

        // POST: LOAIMATHANG/Edit/5
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

        // GET: LOAIMATHANG/Delete/5
        public ActionResult Delete(string id)
        {
            ViewBag.Check = 0;
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

        // POST: LOAIMATHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAIMATHANG lOAIMATHANG = db.LOAIMATHANG.Find(id);
            var maLMH = from m in db.MATHANG select m.MALMH;
            if (maLMH.Contains(id))
            {
                ViewBag.Check = 1;
                ViewBag.Error = "Xóa các mặt hàng liên quan đến loại mặt hàng này";
                return View(lOAIMATHANG);
            }
            else
            {
                db.LOAIMATHANG.Remove(lOAIMATHANG);
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
