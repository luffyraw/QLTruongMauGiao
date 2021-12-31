namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
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
            LOPs = new HashSet<LOP>();
        }

        [Key]
        [StringLength(5)]
        public string MaTre { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPH { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTre { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        public bool GioiTinh { get; set; }

        [Required]
        [StringLength(50)]
        public string QueQuan { get; set; }

        [Required]
        [StringLength(30)]
        public string DanToc { get; set; }

        public DateTime NgayNhapHoc { get; set; }

        [Required]
        [StringLength(100)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMDANH> DIEMDANHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDANHGIA> PHIEUDANHGIAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHUTIEN> PHIEUTHUTIENs { get; set; }

        public virtual PHUHUYNH PHUHUYNH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOPs { get; set; }
    }
}
