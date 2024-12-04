using QLBANHANG.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace QLBANHANG.Controllers
{
    public class ThongKeController : Controller
    {
        private QLBH db = new QLBH();
        // GET: ThongKe
        public ActionResult Index()
        {
            var toDay = DateTime.Today;
            var querry = from hd in db.HOADON
                         join cthd in db.CHITIETHOADON
                         on hd.MAHD equals cthd.MAHD
                         select new
                         {
                             ngaylap = hd.NGAYLAPHD,
                             mamh = cthd.MAMH,
                             soluong = cthd.SOLUONGMH,
                             tenmh = cthd.MATHANG.TENMH
                         };

            var spbc = querry.Where(m => DbFunctions.TruncateTime(m.ngaylap) == toDay).GroupBy(m => m.tenmh).Select(x => new SanPhamBanChay
            {
                tenMH = x.Key,
                tongSoLuong = x.Sum(t => t.soluong),
            }).OrderByDescending(m => m.tongSoLuong);
            var sphh = db.MATHANG.Where(m => m.SOLUONGTK <= 20);
            ThongKeSanPham thongKeSP = new ThongKeSanPham();
            thongKeSP.sanPhamBanChay = spbc.ToList();
            thongKeSP.sanPhamHetHang = sphh.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult LayDuLieu(string fromDay, string toDay)
        {
            var querry = from hd in db.HOADON
                         join cthd in db.CHITIETHOADON
                         on hd.MAHD equals cthd.MAHD
                         select new
                         {
                             ngaylap = hd.NGAYLAPHD,
                             giaban = cthd.MATHANG.GIABAN,
                             giamua = cthd.MATHANG.GIAMUA,
                             soluong = cthd.SOLUONGMH
                         };
            if (!string.IsNullOrEmpty(fromDay))
            {
                DateTime startDay = DateTime.ParseExact(fromDay, "dd/MM/yyyy", null);
                querry = querry.Where(l => l.ngaylap >= startDay);
            }
            if (!string.IsNullOrEmpty(toDay))
            {
                DateTime endDay = DateTime.ParseExact(toDay, "dd/MM/yyyy", null);
                querry = querry.Where(l => l.ngaylap <= endDay);
            }
            var result = querry.GroupBy(r => DbFunctions.TruncateTime(r.ngaylap)).Select(x => new
            {
                NgayLapDon = x.Key.Value,
                DoanhThu = x.Sum(m => m.soluong * m.giaban),
                LoiNhuan = x.Sum(m => m.soluong * m.giaban) - x.Sum(m => m.soluong * m.giamua)
            });
            return Json(new {Data = result}, JsonRequestBehavior.AllowGet);
        }
    }
}