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
    public class TrangChuController : Controller
    {
        private QLBH db = new QLBH();
        static List<MATHANG> ls = new List<MATHANG>();
        // GET: TrangTru
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult TimKiem()
        {
            ls.Clear();
            var mATHANG = db.MATHANG.Include(m => m.LOAIMATHANG);
            return View(mATHANG.ToList());
        }

        public ActionResult KiemTra()
        {
            return View();
        }
        public ActionResult XuLyDonHang()
        {
            var mATHANG = db.MATHANG.Include(m => m.LOAIMATHANG);
            ls.Clear();
            return View(ls);
        }

        [HttpPost]
        public ActionResult XuLyDonHang(string mahang)
        {
            ViewBag.ErrorDisplay = "none";
            if (!db.MATHANG.Any(m => m.MAMH == mahang))
            {
                ViewBag.Message = "Mặt hàng không tồn tại trong cơ sở dữ liệu";
                ViewBag.Check = 1;
                ViewBag.Icon = "fas fa-exclamation-circle";
                ViewBag.Display = "btn btn-warning";
                return View(ls);
            }

            if (ls.Any(m => m.MAMH.ToLower() == mahang))
            {
                ViewBag.Message = "Mặt hàng đã được thêm vào đơn hàng";
                ViewBag.Check = 1;
                ViewBag.Icon = "fas fa-exclamation-circle";
                ViewBag.Display = "btn btn-warning";
                return View(ls);
            }
            var item = db.MATHANG.Find(mahang);
            ls.Add(item);
            return View(ls);
        }

        [HttpPost]
        public ActionResult XuLyHoaDon(string[] soluong)
        {
            if (ls.Count() == 0)
            {
                ViewBag.Message = "Không có hàng nào để thanh toán";
                ViewBag.Check = 1;
                ViewBag.Icon = "fas fa-exclamation-circle";
                ViewBag.Display = "btn btn-warning";
                return View("XuLyDonHang", ls);
            }
            //Kiểm tra xem số lượng có đủ hay không
            for (int i = 0; i < ls.Count(); i++)
            {
                if (int.Parse(soluong[i]) > ls.ElementAt(i).SOLUONGTK)
                {
                    var ma = ls.ElementAt(i).MAMH;
                    ViewBag.Icon = "fas fa-exclamation-circle";
                    ViewBag.Check = 1;
                    ViewBag.Message = "Mặt hàng " + ma + " không có đủ số lượng tồn kho";
                    ViewBag.Display = "btn btn-warning";
                    return View("XuLyDonHang", ls);
                }
            }

            //Them vao bang hoa don
            var hoadon = new HOADON();
            if (db.HOADON.ToList().Count() == 0) hoadon.MAHD = "001";
            else
            {
                var temphoadon = db.HOADON.OrderByDescending(p => p.MAHD).ToList().First();
                int number = int.Parse(temphoadon.MAHD) + 1;
                hoadon.MAHD = number.ToString("D3");
            }
            var mahd = hoadon.MAHD;
            hoadon.NGAYLAPHD = DateTime.Today;
            db.HOADON.Add(hoadon);
            db.SaveChanges();
            //Them vao bang chi tiet hoa don + update table MATHANG
            for (int i = 0; i < ls.Count(); i++)
            {
                var chitiet = new CHITIETHOADON();
                chitiet.MAHD = mahd;
                chitiet.MAMH = ls.ElementAt(i).MAMH;
                chitiet.SOLUONGMH = int.Parse(soluong[i]);
                db.CHITIETHOADON.Add(chitiet);
                //update so luong mat hang
                var mathang = db.MATHANG.Find(ls.ElementAt(i).MAMH);
                mathang.SOLUONGTK -= int.Parse(soluong[i]);
                db.SaveChanges();
            }
            var listCTHD = db.CHITIETHOADON.Where(m => m.MAHD == mahd).ToList();
            foreach (var hd in listCTHD)
            {
                hd.thanhtien = hd.MATHANG.GIABAN * hd.SOLUONGMH;
            }
            var ngayLap = db.HOADON.Where(m => m.MAHD == mahd).Select(m => m.NGAYLAPHD).FirstOrDefault();
            ViewBag.Mahd = db.HOADON.Where(m => m.MAHD == mahd).Select(m => m.MAHD).FirstOrDefault();
            ViewBag.Ngaylap = String.Format("{0:dd/MM/yyyy}", ngayLap);
            ViewBag.Tongtien = String.Format("{0:C0}", listCTHD.Sum(m => m.thanhtien));
            return View("XuatHoaDon", listCTHD);
        }

        [HttpPost]
        public ActionResult Reset()
        {
            ls.Clear();
            return View("XuLyDonHang", ls);
        }

        public ActionResult XuatHoaDon()
        {
            return View();
        }
    }
}