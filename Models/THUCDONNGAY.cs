namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("THUCDONNGAY")]
    public partial class THUCDONNGAY
    {
        [Key]
        [StringLength(10)]
        [DisplayName("Mã")]
        [Required(ErrorMessage = "Không được để trống")]
        public string MaTDN { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày")]
        [Required(ErrorMessage = "Không được để trống")]
        public DateTime Ngay { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(500)]
        [DisplayName("Bữa sáng")]
        public string BuaSang { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(500)]
        [DisplayName("Bữa trưa")]
        public string BuaTrua { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(500)]
        [DisplayName("Bữa xế")]
        public string BuaXe { get; set; }
    }
}
