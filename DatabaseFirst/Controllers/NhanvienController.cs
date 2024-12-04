using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class NhanvienController : Controller
    {
        //Hiển thị toàn bộ danh sách các thông tin của nhân viên trong bảng Nhanvien
        public ActionResult Index(string filter, int ?id)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            List<Nhanvien> ls = qlnv.Nhanvien.Where(model => model.tennhanvien.ToLower().Contains(filter.ToLower()) == true && (model.maphong == id || id == null)).ToList();
            if(ls.Count == 0)
            {
                return View(qlnv.Nhanvien.ToList());
            }
            else
            {
                return View(ls);
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
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            if (ImageFile.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Images/");
                string path = rootFolder + ImageFile.FileName;
                ImageFile.SaveAs(path);

                nv.hinhanh = "/Images/" + ImageFile.FileName;
            }
            qlnv.Nhanvien.Add(nv);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }

        //Chỉnh sửa thông tin nhân viên
        public ActionResult Edit(int id)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            Nhanvien nv = qlnv.Nhanvien.Find(id);
            return View(nv);
        }
        [HttpPost]
        public ActionResult Edit(Nhanvien nv, HttpPostedFileBase ImageFile)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            if (ImageFile.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Images/");
                string path = rootFolder + ImageFile.FileName;
                ImageFile.SaveAs(path);

                nv.hinhanh = "/Images/" + ImageFile.FileName;
            }
            var editnv = qlnv.Nhanvien.Find(nv.manhanvien);
            editnv.manhanvien = nv.manhanvien;
            editnv.tennhanvien = nv.tennhanvien;
            editnv.ngaysinh = nv.ngaysinh;
            editnv.hinhanh = nv.hinhanh;
            editnv.maphong = nv.maphong;
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }

        //Xoá bỏ nhân viên
        public ActionResult Delete(int? id)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            var nv = qlnv.Nhanvien.Find(id);
            qlnv.Nhanvien.Remove(nv);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }

        //Chi tiết thông tin nhân viên
        public ActionResult Details(int? id)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Nhanvien nv = qlnv.Nhanvien.Find(id);
            if (nv == null) 
                return HttpNotFound(); 
            return View(nv);
        }
    }
}