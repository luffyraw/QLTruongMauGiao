namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEMDANH")]
    public partial class DIEMDANH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string MaTre { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Ngay { get; set; }

        [Column("DiemDanh")]
        public bool DiemDanh1 { get; set; }

        public bool DangKiBuaAn { get; set; }

        public virtual NGAYDIHOC NGAYDIHOC { get; set; }

        public virtual TRE TRE { get; set; }
    }
}
