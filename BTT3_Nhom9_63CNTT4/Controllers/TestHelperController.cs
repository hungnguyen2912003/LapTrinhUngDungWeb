using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTT3_Nhom9_63CNTT4.Controllers
{
    public class TestHelperController : Controller
    {
        // GET: TestHelper
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult upload()
        {
            return View();
        }
        public ActionResult upload(HttpPostedFileBase upload)
        {
            var fileName = System.IO.Path.GetFileName(upload.FileName);
            upload.SaveAs(Server.MapPath("~/Images/" + fileName));
            return View();
        }
    }
}