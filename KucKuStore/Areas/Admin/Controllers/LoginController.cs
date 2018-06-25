using KucKuStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KucKuStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        DbContent db = new DbContent();

        [HttpGet]
        public ActionResult DangNhap1()
        {
            return View();
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DangNhap1(FormCollection f)
        {
            string sUsername = f["username"].ToString();
            string sMK = f.Get("pass").ToString();
            NGUOIDUNG ng = db.NGUOIDUNGs.SingleOrDefault(n => n.TENDN == sUsername && n.MATKHAU == sMK);

            if (ng != null)
            {
                Session["taikhoan"] = ng; // gán session là cẩ đối tượng ng
                return RedirectToAction("Index","TaiKhoanAdmin");
            }
            ViewBag.ThongBao = "Đăng nhập sai! Chỉ dành người quản trị hệ thống.";
            return View("DangNhap");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap");
        }
    }
}