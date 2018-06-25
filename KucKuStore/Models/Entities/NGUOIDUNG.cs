namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAND { get; set; }


        [StringLength(30)]
        [Display(Name = "Tên đăng nhập")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Tên đăng nhập không để trống")]
        public string TENDN { get; set; }

        [StringLength(30)]
        [Display(Name = "Mật khẩu")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Mật khẩu không để trống")]
        public string MATKHAU { get; set; }

        [StringLength(30)]
        [Display(Name = "Mail")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Mail không để trống")]
        public string MAIL { get; set; }
    }
}
