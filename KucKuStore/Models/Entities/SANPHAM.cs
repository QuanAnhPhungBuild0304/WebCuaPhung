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

        //[Key]
        //public int MASP { get; set; }

        //[StringLength(200)]
        //public string TENSP { get; set; }

        //public int? GIA { get; set; }

        //public int? GIAMGIA { get; set; }

        //[StringLength(10)]
        //public string MADM { get; set; }

        //[StringLength(500)]
        //public string CHITIET { get; set; }

        //[StringLength(200)]
        //public string HINHANH { get; set; }


        //public int? SOLUONG { get; set; }

        //public DateTime? NGAYNHAP { get; set; }

        //[StringLength(30)]
        //public string MANCC { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MASP { get; set; }

        [StringLength(200)]
        [Display(Name = "Tên sản phẩm")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string TENSP { get; set; }
        [Display(Name = "Giá")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public int? GIA { get; set; }
        [Display(Name = "Sale")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public int? GIAMGIA { get; set; }


        [StringLength(10)]
        [Display(Name = "Danh mục")]
        // validate check cho hệ thống.

        public string MADM { get; set; }

        [StringLength(500)]
        [Display(Name = "Chi tiết")]

        public string CHITIET { get; set; }

        [StringLength(200)]
        [Display(Name = "Hình ảnh")]

        public string HINHANH { get; set; }


        [Display(Name = "Số lượng")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public int? SOLUONG { get; set; }

        [Display(Name = "Ngày nhập kho")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NGAYNHAP { get; set; }

        [StringLength(30)]

        [Display(Name = "Nhà cung cấp")]
        // validate check cho hệ thống.

        public string MANCC { get; set; }


        public virtual DANHMUC DANHMUC { get; set; }

        public virtual NHACC NHACC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }
    }
}
