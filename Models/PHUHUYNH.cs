namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHUHUYNH")]
    public partial class PHUHUYNH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHUHUYNH()
        {
            TREs = new HashSet<TRE>();
        }

        [Key]
        [StringLength(5)]
        [Required(ErrorMessage = "Không được để trống")]
        public string MaPH { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống")]
        public string TenPH { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Không được để trống")]
        public DateTime NamSinh { get; set; }

        public bool GioiTinh { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(15)]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(20)]
        public string TenTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRE> TREs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
