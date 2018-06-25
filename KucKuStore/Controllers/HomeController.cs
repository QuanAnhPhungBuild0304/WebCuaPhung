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
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            var model = new SANPHAMF().DSSanPham.ToList();
            ViewBag.DANHMUC = new DANHMUCF().DanhMUcs.ToList();


            var cart = (Cart)Session[CartSession];
            ViewBag.list = new List<CartItem>();
            if (cart != null)
            {
                ViewBag.list = cart.Lines.ToList();
                ViewBag.Count = cart.Lines.Count();
                ViewBag.TongTien = cart.ComputeTotalValue();
            }
            else
            {
                ViewBag.TongTien = 0;
                ViewBag.Count = 0;
            }
            return View(model);
        }
        public ActionResult Sale(int? page)
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();
            var model = new SANPHAMF().DSSanPham.Where(x => x.GIAMGIA > 0).ToList();

            //Phân trang
            int pageSize = 9;
            int pageNum = (page ?? 1);
            return View(model.OrderByDescending(n=>n.GIAMGIA).ToPagedList(pageNum,pageSize));
        }
    
    }
}