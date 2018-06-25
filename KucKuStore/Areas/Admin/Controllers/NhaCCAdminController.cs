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
    public class NhaCCAdminController : BaseController
    {
        // GET: Admin/NhaCCAdmin
        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.NHACCs.ToList().OrderBy(a => a.TENNCC).ToPagedList(pageNumb, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NHACC ncc)
        {
            if (ModelState.IsValid)
            {
                db.NHACCs.Add(ncc);

                db.SaveChanges();
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(string MANCC)
        {
            NHACC dt = db.NHACCs.SingleOrDefault(n => n.MANCC == MANCC);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NHACC dt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HienThi(string MANCC)
        {
            // lấy ra đt sp theo mã
            NHACC dt = db.NHACCs.SingleOrDefault(n => n.MANCC == MANCC);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }

        [HttpGet]
        public ActionResult Xoa(string MANCC)
        {
            // lấy ra đt dm theo mã
            NHACC dt = db.NHACCs.SingleOrDefault(n => n.MANCC == MANCC);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacnhanXoa(string MANCC)
        {
            NHACC dt = db.NHACCs.SingleOrDefault(n => n.MANCC == MANCC);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NHACCs.Remove(dt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}