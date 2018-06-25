namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHUYENMAI")]
    public partial class KHUYENMAI
    {
        [Key]
        [StringLength(10)]
        public string MAKM { get; set; }

        [StringLength(50)]
        public string TEMKM { get; set; }

        [StringLength(50)]
        public string NDKM { get; set; }

        [StringLength(50)]
        public string HINHANH { get; set; }
    }
}
