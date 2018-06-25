using KucKuStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KucKuStore.Models.Functions
{
    public class SANPHAMF
    {
        private DbContent context;

        public SANPHAMF()
        {
            context = new DbContent();
        }

        // Trả về danh muc
        public IQueryable<SANPHAM> DSSanPham
        {
            get { return context.SANPHAMs; }
        }
        public List<SANPHAM> GetList()
        {
            return context.SANPHAMs.ToList();
        }
        public List<SANPHAM> GetList1(string id)
        {
            return context.SANPHAMs.Where(x => x.MADM.Contains(id)).ToList();
        }
        // Trả về một đối tượng danh mục, khi biết Khóa
        public SANPHAM FindEntity(int MaSP)
        {
            SANPHAM dbEntry = context.SANPHAMs.Find(MaSP);
            return dbEntry;
        }
    }
}