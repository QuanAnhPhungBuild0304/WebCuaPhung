namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }

        [Key]
        public int MASP { get; set; }

        [StringLength(200)]
        public string TENSP { get; set; }

        public int? GIA { get; set; }

        public int? GIAMGIA { get; set; }

        [StringLength(10)]
        public string MADM { get; set; }

        [StringLength(500)]
        public string CHITIET { get; set; }

        [StringLength(200)]
        public string HINHANH { get; set; }

        [StringLength(200)]
        public string HINHANHKHAC { get; set; }

        public int? SOLUONG { get; set; }

        public DateTime? NGAYNHAP { get; set; }

        [StringLength(30)]
        public string MANCC { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        public virtual NHACC NHACC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }
    }
}
