using KucKuStore.Models.Entities;
using KucKuStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace KucKuStore.Controllers
{
    public class CartController : Controller
    {// GET: Cart
        private const string CartSession = "CartSession";
        DbContent db = new DbContent();
        public ActionResult GioHang()
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();

            var cart = (Cart)Session[CartSession];

            var list = new List<CartItem>();

            if (cart != null)
            {
                //ViewBag.list = cart.Lines.ToList();
                ViewBag.Count = cart.Lines.Count();
                ViewBag.TongTien = cart.ComputeTotalValue();

                if (cart.Lines != null)
                {
                    list = cart.Lines.ToList();
                }                
            }

            return View(list.ToList());
        }
        public ActionResult AddItem(int Id, string returnURL)
        {

            var product = new SANPHAMF().FindEntity(Id);

            var cart = (Cart)Session[CartSession];

            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session[CartSession] = cart;
                //return Redirect(returnURL);
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session[CartSession] = cart;
                //return Redirect(returnURL);
            }

            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("GioHang");
            }

            return Redirect(returnURL);
        } 
        //Xóa 1 sản phẩm
        public ActionResult RemoveLine(int id)
        {
            var product = new SANPHAMF().FindEntity(id);
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                cart.RemoveLine(product);
                Session[CartSession] = cart;
            }
            return RedirectToAction("GioHang");
            
        }
        public ActionResult Clear()     //Xóa đơn hàng
        {
            var cart = (Cart)Session[CartSession];
            cart.Clear();
            Session[CartSession] = cart;
            return RedirectToAction("GioHang");
        }
        public ActionResult UpdateCart(int id,FormCollection fr)
        {
            var product = new SANPHAMF().FindEntity(id);
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                int sl = int.Parse(fr["txtQuantity"].ToString());
                cart.UpdateItem(product, sl);
                Session[CartSession] = cart;
            }
            else
            {
                cart = new Cart();
                cart.AddItem(product, 1);
                Session[CartSession] = cart;
            }
            return RedirectToAction("GioHang");
        }
        [HttpGet]
        public ActionResult ThanhToan()
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();

            var cart = (Cart)Session[CartSession];
            var list = new List<CartItem>();
            if(cart !=null)
            {
                list = cart.Lines.ToList();
                
                ViewBag.TongTien = cart.ComputeTotalValue();
                ViewBag.Count = cart.Lines.Count();
            }
            else
            {
                ViewBag.TongTien = 0;
                ViewBag.Count = 0;
            }

            return View(list.ToList());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThanhToan([Bind(Include ="MADH,TENKH,DIACHI,DIENTHOAI,EMAIL,TRANGTHAI,NGAYTAO,GHICHU")]
        DONHANG donhang ,string tenkh, string diachi, string sdt, string email, string ghichu,string trangthai)
        {
            donhang.TENKH = tenkh;
            donhang.DIACHI = diachi;
            donhang.DIENTHOAI = sdt;
            donhang.EMAIL = email;
            
            donhang.NGAYTAO = DateTime.Now;
            donhang.GHICHU = ghichu;
            if(trangthai=="0") donhang.TRANGTHAI = false;
            else donhang.TRANGTHAI = true;

            var cart = (Cart)Session[CartSession];
            decimal tong = 0;
            try
            {
                if (cart != null)
                {
                    
                        db.DONHANGs.Add(donhang);
                        db.SaveChanges();
                        var ID = (from x in db.DONHANGs orderby x.MADH descending select x.MADH).Take(1).Single();
                        foreach (var item in cart.Lines)
                        {
                            var CTDonHang = new CTDONHANG();
                            CTDonHang.MASP = item.SANPHAM.MASP;
                            CTDonHang.MADH = ID;
                            CTDonHang.GIA = item.SANPHAM.GIA - item.SANPHAM.GIAMGIA * item.SANPHAM.GIA / 100;
                            CTDonHang.SL = item.Quantity;

                            db.CTDONHANGs.Add(CTDonHang);
                            tong += (item.SANPHAM.GIA - item.SANPHAM.GIAMGIA * item.SANPHAM.GIA / 100).GetValueOrDefault(0) * item.Quantity;

                        SANPHAM sp = db.SANPHAMs.SingleOrDefault(n=> n.MASP == CTDonHang.MASP);
                        int sl1 = (int)sp.SOLUONG;
                        int sl2 = item.Quantity;
                        int conlai = sl1 - sl2;
                        sp.SOLUONG = conlai;
                        db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                   
                }
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessages = string.Join(";", errorMessages);
                var exceptionMessages = string.Concat(ex.Message, "The validation errors are: ", fullErrorMessages);
                throw new DbEntityValidationException(exceptionMessages, ex.EntityValidationErrors);
            }
            cart = null;
            Session[CartSession] = cart;
            return RedirectToAction("ThanhCong");
        }
        public ActionResult ThanhCong()
        {
            ViewBag.DANHMUC1 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("A")).ToList();
            ViewBag.DANHMUC2 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("Q")).ToList();
            ViewBag.DANHMUC3 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("V")).ToList();
            ViewBag.DANHMUC4 = new DANHMUCF().DanhMUcs.Where(x => x.MADM.Contains("PK")).ToList();

            var cart = (Cart)Session[CartSession];
            ViewBag.Count = 0;
            return View();
        }
    }
}