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
    public class DanhMucAdminController : BaseController
    {
        // GET: Admin/DanhMucAdmin
        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.DANHMUCs.ToList().OrderBy(a => a.TENDM).ToPagedList(pageNumb, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DANHMUC dm)
        {
            if (ModelState.IsValid)
            {
                // chèn dũ liệu vào bảng nguoidung trong model
                db.DANHMUCs.Add(dm);
                // lưu vào csdl
                db.SaveChanges();
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(string MADM)
        {
            DANHMUC dm = db.DANHMUCs.SingleOrDefault(n => n.MADM == MADM);
            if(dm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DANHMUC dm)
        {        
            if (ModelState.IsValid)
            {
                db.Entry(dm).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HienThi(string MADM)
        {
            // lấy ra đt sp theo mã
            DANHMUC dm = db.DANHMUCs.SingleOrDefault(n => n.MADM == MADM);
            if (dm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dm);

        }

        [HttpGet]
        public ActionResult Xoa(string MADM)
        {
            // lấy ra đt dm theo mã
            DANHMUC dm = db.DANHMUCs.SingleOrDefault(n => n.MADM == MADM);
            if (dm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dm);
        }
       
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacnhanXoa(string MADM)
        {
            DANHMUC dm = db.DANHMUCs.SingleOrDefault(n => n.MADM == MADM);
            if (dm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DANHMUCs.Remove(dm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}