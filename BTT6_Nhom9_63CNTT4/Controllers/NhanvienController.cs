using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTT6_Nhom9_63CNTT4.Models;

namespace BTT6_Nhom9_63CNTT4.Controllers
{
    public class NhanvienController : Controller
    {
        //Hiển thị danh sách nhân viên
        public ActionResult Index(string filter)
        {
            DBContext qlnv = new DBContext();
            List<Nhanvien> ls = qlnv.Nhanviens.
                Where(model => model.Hotennv.ToLower().Contains(filter.ToLower()))
                .ToList();
            if (string.IsNullOrEmpty(filter))
            {
                return View(qlnv.Nhanviens.ToList());
            }
            if (ls.Count == 0)
            {
                ViewBag.Count = qlnv.Nhanviens.Count();
                ViewBag.Message = "Không tìm thấy nhân viên có tên " + filter;
                return View(qlnv.Nhanviens.ToList());
            }
            else
            {
                ViewBag.Luong = ls.Sum(model => model.Luong);
                ViewBag.Count = ls.Count();
                return View(ls);
            }
        }
        //Lọc nhân viên bằng DroplistDown
        public ActionResult FilterNhanvien(string filter)
        {
            DBContext qlnv = new DBContext();

            //Lấy danh sách phòng ban từ bảng Phongban
            List<Phongban> pb = qlnv.Phongbans.ToList();

            //Tạo một SelectList để hiển thị danh sách phòng ban trong DropdownList
            SelectList ls = new SelectList(pb, "Tenphong", "Tenphong");

            //Truyền Select đến View để hiển thị Dropdownlist
            ViewBag.PhongBan = ls;

            //Kiểm tra người dùng chọn phòng ban nào chưa
            if(!string.IsNullOrEmpty(filter))
            {
                //Lọc danh sách nhân viên theo Tên phòng ban
                List<Nhanvien> nv = qlnv.Nhanviens.
                    Where(model => model.Phongban.Tenphong == filter).ToList();
                return View(nv);
            }
            else
            {
                //Nếu người dùng chưa chọn phòng ban nào thì hiển thị tất cả nhân viên
                return View(qlnv.Nhanviens.ToList());
            }
        }
        //Thêm mới nhân viên
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Nhanvien nv, HttpPostedFileBase ImageFile)
        {
            DBContext qlnv = new DBContext();
            if(ImageFile.ContentLength > 0)
            {
                string rootfile = Server.MapPath("/Images/");
                string path = rootfile + ImageFile.FileName;
                ImageFile.SaveAs(path);
                nv.Hinhanh = "/Images/" + ImageFile.FileName;
            }
            qlnv.Nhanviens.Add(nv);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }
        //Chỉnh sửa thông tin nhân viên
        public ActionResult Edit(int id)
        {
            DBContext qlnv = new DBContext();
            Nhanvien nv = qlnv.Nhanviens.Find(id);
            return View(nv);
        }
        [HttpPost]
        public ActionResult Edit(Nhanvien nv, HttpPostedFileBase ImageFile)
        {
            DBContext qlnv = new DBContext();
            if(ImageFile.ContentLength > 0)
            {
                string rootfile = Server.MapPath("/Images/");
                string path = rootfile + ImageFile.FileName;
                ImageFile.SaveAs(path);

                nv.Hinhanh = "/Images/" + ImageFile.FileName;
            }
            var newnv = qlnv.Nhanviens.Find(nv.Manv);
            newnv.Manv = nv.Manv;
            newnv.Hotennv = nv.Hotennv;
            newnv.Ngsinh = nv.Ngsinh;
            newnv.Hinhanh = nv.Hinhanh;
            newnv.Maphong = nv.Maphong;
            newnv.MaCV = nv.MaCV;
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xoá bỏ nhân viên ra danh sách
        public ActionResult Delete(int? id)
        {
            DBContext qlnv = new DBContext();
            Nhanvien nv = qlnv.Nhanviens.Find(id);
            qlnv.Nhanviens.Remove(nv);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}