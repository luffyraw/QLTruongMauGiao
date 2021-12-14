namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUCDONNGAY")]
    public partial class THUCDONNGAY
    {
        [Key]
        [StringLength(10)]
        public string MaTDN { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        [Required]
        [StringLength(500)]
        public string BuaSang { get; set; }

        [Required]
        [StringLength(500)]
        public string BuaTrua { get; set; }

        [Required]
        [StringLength(500)]
        public string BuaXe { get; set; }

        public virtual THUCDONTUAN THUCDONTUAN { get; set; }
    }
}
