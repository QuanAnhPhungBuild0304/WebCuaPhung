using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KucKuStore.Models.Entities
{
   [Serializable]
    public class CartItem
    {
        public SANPHAM SANPHAM { get; set; }
        public int Quantity { set; get; }
    }
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(SANPHAM sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.SANPHAM.MASP == sp.MASP)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    SANPHAM = sp,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
                
            }
        }
        public void UpdateItem(SANPHAM sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.SANPHAM.MASP == sp.MASP)
                .FirstOrDefault();

            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.SANPHAM.MASP == sp.MASP);
                }
            }
        }
        public void RemoveLine(SANPHAM sp)
        {
            lineCollection.RemoveAll(l => l.SANPHAM.MASP == sp.MASP);
        }

        public int? ComputeTotalValue()
        {
            return lineCollection.Sum(e => (e.SANPHAM.GIA- e.SANPHAM.GIA* e.SANPHAM.GIAMGIA/100) * e.Quantity);

        }

        public int? ComputeTotalProduct()
        {
            return lineCollection.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    }
}