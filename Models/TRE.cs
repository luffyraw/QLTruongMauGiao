namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("TRE")]
    public partial class TRE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRE()
        {
            DIEMDANHs = new HashSet<DIEMDANH>();
            PHIEUDANHGIAs = new HashSet<PHIEUDANHGIA>();
            PHIEUTHUTIENs = new HashSet<PHIEUTHUTIEN>();
        }

        [Key]
        [StringLength(6)]
        public string MaTre { get; set; }

        [Required(ErrorMessage = "Không được để trống l")]
        [StringLength(5)]
        public string MaLop { get; set; }

        [Required(ErrorMessage = "Không được để trống phụ huynh")]
        [StringLength(5)]
        public string MaPH { get; set; }

        [Required(ErrorMessage = "Không được để trống tên trẻ")]
        [StringLength(100)]
        public string TenTre { get; set; }

        [Required(ErrorMessage = "Không được để trống ngày sinh")]
        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        public bool GioiTinh { get; set; }

        [Required(ErrorMessage = "Không được để trống quê quán")]
        [StringLength(50)]
        public string QueQuan { get; set; }

        [Required(ErrorMessage = "Không được để trống dân tộc")]
        [StringLength(30)]
        public string DanToc { get; set; }

        public DateTime NgayNhapHoc { get; set; }

        [Required(ErrorMessage = "Không được để trống ảnh")]
        [StringLength(30)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMDANH> DIEMDANHs { get; set; }

        public virtual LOP LOP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDANHGIA> PHIEUDANHGIAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHUTIEN> PHIEUTHUTIENs { get; set; }

        public virtual PHUHUYNH PHUHUYNH { get; set; }
    }
}
