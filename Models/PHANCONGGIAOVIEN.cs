namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANCONGGIAOVIEN")]
    public partial class PHANCONGGIAOVIEN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaGV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MaLop { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string NamHoc { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        public virtual LOP LOP { get; set; }
    }
}
