namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("THUCDONNGAY")]
    public partial class THUCDONNGAY
    {
        [Key]
        [StringLength(10)]
<<<<<<< Updated upstream
        [DisplayName("Mã")]
        public string MaTDN { get; set; }

        [Column(TypeName = "date")]

=======
        [DisplayName("Mã thực đơn ngày")]
        public string MaTDN { get; set; }

        [Column(TypeName = "date")]
>>>>>>> Stashed changes
        [DisplayName("Ngày")]
        public DateTime Ngay { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Bữa sáng")]
        public string BuaSang { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Bữa trưa")]
        public string BuaTrua { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Bữa xế")]
        public string BuaXe { get; set; }
    }
}
