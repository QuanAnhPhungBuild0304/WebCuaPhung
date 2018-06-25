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
    public class DonHangAdminController : BaseController
    {
        // GET: Admin/DonHangAdmin
        DbContent db = new DbContent();
        public ActionResult Index(int? pageTemp)
        {
            int pageSize = 5;
            int pageNumb = pageTemp ?? 1;

            return View(db.DONHANGs.ToList().OrderBy(a => a.MADH).ToPagedList(pageNumb, pageSize));
        }


        [HttpGet]
        public ActionResult Edit(int MADH)
        {
            DONHANG dt = db.DONHANGs.SingleOrDefault(n => n.MADH == MADH);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DONHANG dt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult HienThi(int MADH)
        {
            // lấy ra đt sp theo mã
            DONHANG dh = db.DONHANGs.SingleOrDefault(n => n.MADH == MADH);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
    }
}