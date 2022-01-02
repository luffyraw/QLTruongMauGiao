namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("DONGCHIPHI")]
    public partial class DONGCHIPHI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        [DisplayName("Mã phiếu")]
        public string MaPhieu { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        [DisplayName("Mã chi phí")]
        public string MaChiPhi { get; set; }

        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        public virtual CHIPHI CHIPHI { get; set; }

        public virtual PHIEUTHUTIEN PHIEUTHUTIEN { get; set; }
    }
}
