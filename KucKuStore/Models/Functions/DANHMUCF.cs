using KucKuStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KucKuStore.Models.Functions
{
    public class DANHMUCF
    {
        private DbContent context;

        public DANHMUCF()
        {
            context = new DbContent();
        }

        // Trả về danh muc
        public IQueryable<DANHMUC> DanhMUcs
        {
            get { return context.DANHMUCs; }
        }
        public List<DANHMUC> GetList1(string id)
        {
            return context.DANHMUCs.Where(x => x.MADM.Contains(id)).ToList();
        }
        // Trả về một đối tượng danh mục, khi biết Khóa
        public DANHMUC FindEntity(string MaDM)
        {
            DANHMUC dbEntry = context.DANHMUCs.Find(MaDM);
            return dbEntry;
        }
    }
}