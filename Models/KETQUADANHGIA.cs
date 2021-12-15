namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUADANHGIA")]
    public partial class KETQUADANHGIA
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaPhieu { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MaNDDG { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Kết quả")]
        public string kq { get; set; }

        public virtual NOIDUNGDANHGIA NOIDUNGDANHGIA { get; set; }

        public virtual PHIEUDANHGIA PHIEUDANHGIA { get; set; }
    }
}
