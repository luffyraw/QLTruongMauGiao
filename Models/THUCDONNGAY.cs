namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUCDONNGAY")]
    public partial class THUCDONNGAY
    {
        [Key]
        [StringLength(10)]
       
        [DisplayName("Mã thực đơn ngày")]
        public string MaTDN { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
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
    }
}
