namespace KucKuStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LIENHE")]
    public partial class LIENHE
    {
        [Key]
        [StringLength(10)]
        public string MALH { get; set; }

        [StringLength(100)]
        public string NOIDUNG { get; set; }

        public bool? TRANGTHAI { get; set; }
    }
}
