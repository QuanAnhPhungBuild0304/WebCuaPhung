namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHMUC")]
    public partial class DANHMUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANHMUC()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }


        [Key]
        [StringLength(10)]
        [Display(Name = "Mã Danh mục")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Mã danh mục không để trống")]
        public string MADM { get; set; }

        [StringLength(200)]
        [Display(Name = "Tên Danh mục")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Tên Danh mục không để trống")]
        public string TENDM { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề ngắn")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string TIEUDENGAN { get; set; }

        [Display(Name = "Trạng thái")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public bool? TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
