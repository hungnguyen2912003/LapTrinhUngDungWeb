using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using QLBANHANG.Models;

namespace QLBANHANG.Controllers
{
    public class DONNHAPHANGController : Controller
    {
        private QLBH db = new QLBH();

        // GET: DONNHAPHANG
        public ActionResult Index()
        {
            foreach (var dnh in db.DONNHAPHANG)
            {
                dnh.tongtiendnh = db.CHITIETDONNHAPHANG.Where(m => m.MADNH == dnh.MADNH).Sum(m => m.SOLUONGNH * m.MATHANG.GIAMUA);
            }
            return View(db.DONNHAPHANG.ToList());
        }

        public ActionResult Details(string madnh)
        {
            if (madnh == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONNHAPHANG dONNHAPHANG = db.DONNHAPHANG.Find(madnh);
            if (dONNHAPHANG == null)
            {
                return HttpNotFound();
            }
            var ctdnh = db.CHITIETDONNHAPHANG.Where(m => m.MADNH == madnh);
            foreach (var ct in ctdnh)
            {
                ct.thanhtien = ct.MATHANG.GIAMUA * ct.SOLUONGNH;
            }
            dONNHAPHANG.tongtiendnh = ctdnh.Sum(m => m.SOLUONGNH * m.MATHANG.GIAMUA);
            var ngayLap = db.DONNHAPHANG.Where(m => m.MADNH == madnh).Select(m => m.NGAYLAPDNH).FirstOrDefault();
            ViewBag.Madnh = db.DONNHAPHANG.Where(m => m.MADNH == madnh).Select(m => m.MADNH).FirstOrDefault();
            ViewBag.Ngaylapdnh = string.Format("{0:dd/MM/yyyy}", ngayLap);
            ViewBag.Tongtiendnh = string.Format("{0:C0}", dONNHAPHANG.tongtiendnh);
            ViewBag.Trangthai = db.DONNHAPHANG.Where(m => m.MADNH == madnh).Select(m => m.TRANGTHAI).FirstOrDefault();
            return View(ctdnh.ToList());
        }
        // GET: DONNHAPHANG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DONNHAPHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADNH,TRANGTHAI,NGAYLAPDNH,NGAYXACNHANDNH,TONGTIENDNH")] DONNHAPHANG dONNHAPHANG)
        {
            if (ModelState.IsValid)
            {
                var listMADNH = from l in db.DONNHAPHANG select l.MADNH;
                if (listMADNH.Contains(dONNHAPHANG.MADNH))
                {
                    ViewBag.Check = 1;
                    ViewBag.Error = "Không được nhập khóa giống nhau";
                    return View();
                }
                else
                {
                    dONNHAPHANG.NGAYLAPDNH = DateTime.Now;
                    db.DONNHAPHANG.Add(dONNHAPHANG);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(dONNHAPHANG);
        }

        // GET: DONNHAPHANG/Delete/5
        public ActionResult Delete(string madnh)
        {
            if (madnh == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONNHAPHANG dONNHAPHANG = db.DONNHAPHANG.Find(madnh);
            if (dONNHAPHANG == null)
            {
                return HttpNotFound();
            }
            var ctdnh = db.CHITIETDONNHAPHANG.Where(m => m.MADNH == madnh);
            foreach (var ct in ctdnh)
            {
                ct.thanhtien = ct.MATHANG.GIAMUA * ct.SOLUONGNH;
            }
            dONNHAPHANG.tongtiendnh = ctdnh.Sum(m => m.SOLUONGNH * m.MATHANG.GIAMUA);
            var ngayLap = db.DONNHAPHANG.Where(m => m.MADNH == madnh).Select(m => m.NGAYLAPDNH).FirstOrDefault();
            ViewBag.Madnh = db.DONNHAPHANG.Where(m => m.MADNH == madnh).Select(m => m.MADNH).FirstOrDefault();
            ViewBag.Ngaylapdnh = string.Format("{0:dd/MM/yyyy}", ngayLap);
            ViewBag.Tongtiendnh = string.Format("{0:C0}", dONNHAPHANG.tongtiendnh);
            return View(ctdnh.ToList());
        }

        // POST: DONNHAPHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string madnh)
        {
            DONNHAPHANG dONNHAPHANG = db.DONNHAPHANG.Find(madnh);
            var ctdnh = db.CHITIETDONNHAPHANG.Where(m => m.MADNH == madnh);
            foreach (var ct in ctdnh)
            {
                db.CHITIETDONNHAPHANG.Remove(ct);
            }
            db.DONNHAPHANG.Remove(dONNHAPHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        static List<MATHANG> ls = new List<MATHANG>();
        public ActionResult KiemTraHangNhap()
        {
            var mATHANG = db.MATHANG.Include(m => m.LOAIMATHANG);
            ls.Clear();
            return View(ls);
        }

        [HttpPost]
        public ActionResult KiemTraHangNhap(string mahang)
        {
            ViewBag.ErrorDisplay = "none";
            if (!db.MATHANG.Any(m => m.MAMH == mahang))
            {
                ViewBag.Message = "Mặt hàng không tồn tại trong cơ sở dữ liệu";
                ViewBag.Display = "btn btn-warning";
                ViewBag.Check = 1;
                ViewBag.Icon = "fas fa-exclamation-circle";
                return View(ls);
            }

            if (ls.Any(m => m.MAMH == mahang.ToUpper()))
            {
                ViewBag.Message = "Mặt hàng đã được thêm vào đơn hàng";
                ViewBag.Display = "btn btn-warning";
                ViewBag.Check = 1;
                ViewBag.Icon = "fas fa-exclamation-circle";
                return View(ls);
            }

            var item = db.MATHANG.Find(mahang);
            ls.Add(item);
            return View(ls);
        }

        [HttpPost]
        public ActionResult XuLy(string madnh, string[] soluong)
        {
            //Kiem tra xem co match khong 
            var donnhap = db.DONNHAPHANG.Find(madnh);
            if (donnhap == null)
            {
                ViewBag.Message = "Không tìm thấy đơn nhập hàng";
                ViewBag.Display = "btn btn-warning";
                ViewBag.Check = 1;
                ViewBag.Icon = "fas fa-exclamation-circle";
                return View("KiemTraHangNhap", ls);
            }
            if (donnhap.TRANGTHAI == true)
            {
                ViewBag.Message = "Dơn nhập hàng đã xác nhận rồi";
                ViewBag.Display = "btn btn-warning";
                ViewBag.Check = 1;
                ViewBag.Icon = "fas fa-exclamation-circle";
                return View("KiemTraHangNhap", ls);
            }

            for (int i = 0; i < ls.Count(); i++)
            {
                if (db.CHITIETDONNHAPHANG.ToList().Where(p => p.MAMH == ls.ElementAt(i).MAMH && p.MADNH == madnh).Select(p => p.SOLUONGNH) == null)
                {
                    {
                        ViewBag.Message = "Không trùng khớp";
                        ViewBag.Display = "btn btn-warning";
                        ViewBag.Check = 1;
                        ViewBag.Icon = "fas fa-exclamation-circle";
                        return View("KiemTraHangNhap", ls);
                    }
                }
                var chitietsoluong = db.CHITIETDONNHAPHANG.ToList().Where(p => p.MAMH == ls.ElementAt(i).MAMH && p.MADNH == madnh).Select(p => p.SOLUONGNH).First();
                if (chitietsoluong != int.Parse(soluong[i]))
                {
                    ViewBag.Message = "Không trùng khớp";
                    ViewBag.Display = "btn btn-warning";
                    ViewBag.Check = 1;
                    ViewBag.Icon = "fas fa-exclamation-circle";
                    return View("KiemTraHangNhap", ls);
                }
            }

            //Cap nhat trang thai don nhap hang va ngay xac nhan
            db.DONNHAPHANG.Find(madnh).TRANGTHAI = true;
            db.DONNHAPHANG.Find(madnh).NGAYXACNHANDNH = DateTime.Today;
            db.SaveChanges();
            //Cap nhat so luong mat hang
            for (int i = 0; i < ls.Count(); i++)
            {
                var mathang = db.MATHANG.Find(ls.ElementAt(i).MAMH);
                mathang.SOLUONGTK += int.Parse(soluong[i]);
                db.SaveChanges();
            }
            ViewBag.Message = "Trùng khớp";
            ViewBag.Display = "btn btn-success";
            ViewBag.Check = 1;
            ViewBag.Icon = "fas fa-check";
            return View("KiemTraHangNhap", ls);
        }

        [HttpPost]
        public ActionResult Reset()
        {
            ls.Clear();
            return View("KiemTraHangNhap", ls);
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
