namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }

        //[Key]
        //public int MADH { get; set; }

        //[StringLength(250)]
        //public string TENKH { get; set; }

        //[StringLength(250)]
        //public string DIACHI { get; set; }

        //[StringLength(10)]
        //public string DIENTHOAI { get; set; }

        //[StringLength(50)]
        //public string EMAIL { get; set; }

        //public bool? TRANGTHAI { get; set; }

        //public DateTime? NGAYTAO { get; set; }

        //[StringLength(500)]
        //public string GHICHU { get; set; }

        [Key]
        public int MADH { get; set; }

        [StringLength(250)]
        [Display(Name = "Khách hàng")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string TENKH { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string DIACHI { get; set; }

        [StringLength(15)]
        [Display(Name = "SĐT")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string DIENTHOAI { get; set; }

        [StringLength(50)]
        [Display(Name = "Mail")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string EMAIL { get; set; }

        [Display(Name = "Trạng thái (Đã thanh toán/Chưa thanh toán: True/False)")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public bool? TRANGTHAI { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? NGAYTAO { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]

        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }
    }
}
