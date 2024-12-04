using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using KT0720NguyenKhacDuyHung_63132095.Models;
using PagedList;

namespace KT0720NguyenKhacDuyHung_63132095.Controllers
{
    public class SinhVien0720_63132095Controller : Controller
    {
        //Giới thiệu
        public ActionResult GioiThieu_63132095()
        {
            return View();
        }
        //Danh sách
        public ActionResult Index(int? page, int ? pageSize)
        {
            KT0720_63132095Entities qlsv = new KT0720_63132095Entities();
            if(page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 2;
            }
            var sv = qlsv.SINHVIEN.ToList();
            return View(sv.ToPagedList((int)page,(int)pageSize));
        }

        //Tìm kiếm
        public ActionResult TimKiem_63132095(string mssv, string hoten, int? page, int? pageSize)
        {
            KT0720_63132095Entities qlsv = new KT0720_63132095Entities();
            var sv = qlsv.SINHVIEN.ToList();
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 2;
            }
            if(!string.IsNullOrEmpty(mssv) && !string.IsNullOrEmpty(hoten))
            {
                List<SINHVIEN> ls = qlsv.SINHVIEN.Where(model => model.MaSV.ToLower().Contains(mssv) && model.HoSV.ToLower().Contains(hoten) ||
                model.MaSV.ToLower().Contains(mssv) && model.TenSV.ToLower().Contains(hoten)).ToList();
                return View(ls.ToPagedList((int)page, (int)pageSize));
            }
            else if (!string.IsNullOrEmpty(mssv) && string.IsNullOrEmpty(hoten))
            {
                List<SINHVIEN> ls = qlsv.SINHVIEN.Where(model => model.MaSV.ToLower().Contains(mssv)).ToList();
                return View(ls.ToPagedList((int)page, (int)pageSize));
            }

            else if (!string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(mssv))
            {
                List<SINHVIEN> ls = qlsv.SINHVIEN.Where(model => model.HoSV.ToLower().Contains(hoten) ||
                model.TenSV.ToLower().Contains(hoten)).ToList();
                return View(ls.ToPagedList((int)page, (int)pageSize));
            }
            else
                return View(sv.ToPagedList((int)page,(int)pageSize));
        }

        //Chi tiết
        public ActionResult Details(string id)
        {
            KT0720_63132095Entities qlsv = new KT0720_63132095Entities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sv = qlsv.SINHVIEN.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return View(sv);
        }

        //Tạo mới
        public ActionResult Create()
        {
            KT0720_63132095Entities qlsv = new KT0720_63132095Entities();
            List<LOP> lp = qlsv.LOP.ToList();
            SelectList ls = new SelectList(lp, "Malop", "Tenlop");
            ViewBag.LopList = ls;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SINHVIEN sv, HttpPostedFileBase ImgFile)
        {
            if (ModelState.IsValid)
            {
                KT0720_63132095Entities qlsv = new KT0720_63132095Entities();
                List<LOP> lp = qlsv.LOP.ToList();
                SelectList ls = new SelectList(lp, "Malop", "Tenlop");
                ViewBag.LopList = ls;

                if (ImgFile != null && ImgFile.ContentLength > 0)
                {
                    string saveFile = Server.MapPath("/Images/");
                    string path = saveFile + ImgFile.FileName;
                    ImgFile.SaveAs(path);
                    sv.AnhSV = "/Images/" + ImgFile.FileName;
                }

                qlsv.SINHVIEN.Add(sv);
                qlsv.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                KT0720_63132095Entities qlsv = new KT0720_63132095Entities();
                List<LOP> lp = qlsv.LOP.ToList();
                SelectList ls = new SelectList(lp, "Malop", "Tenlop");
                ViewBag.LopList = ls;
                return View(sv);
            }
        }

    }
}
