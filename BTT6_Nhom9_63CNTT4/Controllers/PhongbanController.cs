using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTT6_Nhom9_63CNTT4.Models;
namespace BTT6_Nhom9_63CNTT4.Controllers
{
    public class PhongbanController : Controller
    {
        //Hiển thị danh sách phòng ban
        public ActionResult Index()
        {
            return View(new DBContext().Phongbans.ToList());
        }

        //Tạo mới phòng ban

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Phongban pb)
        {
            DBContext qlnv = new DBContext();
            qlnv.Phongbans.Add(pb);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }

        //Chỉnh sửa phòng ban
        public ActionResult Edit(int id)
        {
            DBContext qlnv = new DBContext();
            Phongban pb = qlnv.Phongbans.Find(id);
            return View(pb);
        }

        [HttpPost]
        public ActionResult Edit(Phongban pb)
        {
            DBContext qlnv = new DBContext();
            var editpb = qlnv.Phongbans.Find(pb.Maphong);
            editpb.Maphong = pb.Maphong;
            editpb.Tenphong = pb.Tenphong;
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }

        //Xoá bỏ phòng ban
        public ActionResult Delete(int id)
        {
            DBContext qlnv = new DBContext();
            var nv = qlnv.Phongbans.Find(id);
            qlnv.Phongbans.Remove(nv);
            qlnv.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}