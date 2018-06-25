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
        public int MAND { get; set; }

        [StringLength(30)]
        public string TENDN { get; set; }

        [StringLength(30)]
        public string MATKHAU { get; set; }

        [StringLength(30)]
        public string EMAIL { get; set; }
    }
}
