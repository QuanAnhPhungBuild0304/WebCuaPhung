using KucKuStore.Models.Entities;
using KucKuStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace KucKuStore.Controllers
{
    public class SanPhamController : Controller
    {
        DbContent db = new DbContent();
        // GET: SanPham
        private const string CartSession = "CartSession";
        public ActionResult Shop(string id)
        {
            var item = new DANHMUCF().FindEntity(id);
            // ViewBag.DANHMUC = new DANHMUCF().DanhMUcs.ToList();
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            ViewBag.SANPHAM1 = new SANPHAMF().DSSanPham.Where(x => x.MADM.Contains(id)).ToList();
            
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                ViewBag.Count = cart.Lines.Count();
            }
            else ViewBag.Count = 0;
                

            return View(item);
        }
        public ActionResult SPMoi(int? page)
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            var model = new SANPHAMF().DSSanPham.ToList();


            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                ViewBag.Count = cart.Lines.Count();
            }
            else ViewBag.Count = 0;

            //Phân trang
            int pageSize = 9;
            int pageNum = (page ?? 1);
            return View(model.OrderByDescending(n=>n.NGAYNHAP).ToPagedList(pageNum, pageSize));
        }
        public ActionResult Sort(string select)
        {
            if (select == "moinhat")
            {
                var model = new SANPHAMF().DSSanPham.ToList();
                return View("", model.OrderByDescending(n => n.NGAYNHAP));
            }
            return View("SPMoi");
        }
        public ActionResult ChiTietSP(int id)
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            var model = new SANPHAMF().FindEntity(id);


            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                ViewBag.Count = cart.Lines.Count();
            }
            else ViewBag.Count = 0;

            return View(model);
        }
        public ActionResult TimKIem(string search)

        {
            var item = new SANPHAMF().DSSanPham.Where(x=>x.TENSP.Contains(search) || x.GIA.ToString()==search  || (x.GIA-x.GIA*x.GIAMGIA/100).ToString() == search).ToList();
            // ViewBag.DANHMUC = new DANHMUCF().DanhMUcs.ToList();
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            ViewBag.SANPHAM1 = new SANPHAMF().DSSanPham.Where(x => x.MADM.Contains(search)).ToList();

            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                ViewBag.Count = cart.Lines.Count();
            }
            else ViewBag.Count = 0;

            var query = from sp in db.SANPHAMs
                        where sp.TENSP == search
                        select sp;
            
            return View(item);
        }
    }
}