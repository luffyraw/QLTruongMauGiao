namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        [StringLength(5)]
        [DisplayName("Mã số")]
        public string MaTre { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("Mã phụ huynh")]
        public string MaPH { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên trẻ")]
        public string TenTre { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Quê quán")]
        public string QueQuan { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Dân tộc")]
        public string DanToc { get; set; }
        [DisplayName("Ngày nhập học")]
        public DateTime NgayNhapHoc { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Ảnh")]
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
