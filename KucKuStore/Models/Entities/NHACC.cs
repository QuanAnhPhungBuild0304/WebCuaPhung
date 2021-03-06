﻿namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACC")]
    public partial class NHACC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACC()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }

        //[Key]
        //[StringLength(30)]
        //public string MANCC { get; set; }

        //[StringLength(50)]
        //public string TENNCC { get; set; }

        //[StringLength(50)]
        //public string EMAIL { get; set; }

        //[StringLength(10)]
        //public string SDT { get; set; }


        [Key]
        [StringLength(30)]
        [Display(Name = "Mã Nhà cung cấp")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string MANCC { get; set; }


        [StringLength(50)]
        [Display(Name = "Tên Nhà cung cấp")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string TENNCC { get; set; }


        [StringLength(50)]
        [Display(Name = "Mail")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string EMAIL { get; set; }


        [StringLength(10)]
        [Display(Name = "SĐT")]
        // validate check cho hệ thống.
        [Required(ErrorMessage = "Không để trống")]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
