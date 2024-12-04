using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class PhongbanController : Controller
    {
        //Hiển thị danh sách phòng ban
        public ActionResult Index()
        {
            return View(new QLNhanvien_DatabaseFirstEntities().Phongban.ToList());
        }

        //Tạo mới phòng ban

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Phongban pb)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            qlnv.Phongban.Add(pb);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }

        //Chỉnh sửa phòng ban
        public ActionResult Edit(int id)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            Phongban pb = qlnv.Phongban.Find(id);
            return View(pb);
        }

        [HttpPost]
        public ActionResult Edit(Phongban pb)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            var editpb = qlnv.Phongban.Find(pb.maphong);

            editpb.maphong = pb.maphong;
            editpb.tenphong = pb.tenphong;
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }

        //Xoá bỏ phòng ban
        public ActionResult Delete(int id)
        {
            QLNhanvien_DatabaseFirstEntities qlnv = new QLNhanvien_DatabaseFirstEntities();
            var nv = qlnv.Phongban.Find(id);
            qlnv.Phongban.Remove(nv);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}