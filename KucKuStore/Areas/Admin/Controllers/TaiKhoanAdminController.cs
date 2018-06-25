using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using KucKuStore.Models.Entities;

namespace KucKuStore.Areas.Admin.Controllers
{
    public class TaiKhoanAdminController : BaseController
    {
        // GET: Admin/TaiKhoanAdmin

        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.NGUOIDUNGs.ToList().OrderBy(a => a.TENDN).ToPagedList(pageNumb, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(NGUOIDUNG acc)
        {
            if (ModelState.IsValid)
            {
                // chèn dũ liệu vào bảng nguoidung trong model
                db.NGUOIDUNGs.Add(acc);
                // lưu vào csdl
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public ActionResult Edit(int MAND)
        {
            // lấy ra đt sp theo mã
            NGUOIDUNG ng = db.NGUOIDUNGs.SingleOrDefault(n => n.MAND == MAND);
            if (ng == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ng);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NGUOIDUNG ng)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ng).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int MAND)
        {
            // lấy ra đt dm theo mã
            NGUOIDUNG ng = db.NGUOIDUNGs.SingleOrDefault(n => n.MAND == MAND);
            if (ng == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ng);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacnhanXoa(int MAND)
        {
            NGUOIDUNG ng = db.NGUOIDUNGs.SingleOrDefault(n => n.MAND == MAND);
            if (ng == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NGUOIDUNGs.Remove(ng);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HienThi(int MAND)
        {
            // lấy ra đt sp theo mã
            NGUOIDUNG dt = db.NGUOIDUNGs.SingleOrDefault(n => n.MAND == MAND);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);

        }


    }
}