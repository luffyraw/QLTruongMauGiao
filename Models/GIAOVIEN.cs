namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAOVIEN")]
    public partial class GIAOVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAOVIEN()
        {
            PHIEUDANHGIAs = new HashSet<PHIEUDANHGIA>();
            PHANCONGGIAOVIENs = new HashSet<PHANCONGGIAOVIEN>();
        }

        [Key]
        [StringLength(5)]
        public string MaGV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        public bool GioiTinh { get; set; }

        [Required]
        [StringLength(30)]
        public string QueQuan { get; set; }

        [Required]
        [StringLength(15)]
        public string DienThoai { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string LoaiHopDong { get; set; }

        [Column(TypeName = "money")]
        public decimal Luong { get; set; }

        [Required]
        [StringLength(30)]
        public string KinhNghiem { get; set; }

        [Required]
        [StringLength(30)]
        public string TrinhDo { get; set; }

        [Required]
        [StringLength(30)]
        public string ChuyenNganh { get; set; }

        [Required]
        [StringLength(30)]
        public string LoaiTotNghiep { get; set; }

        [Required]
        [StringLength(20)]
        public string TenTK { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDANHGIA> PHIEUDANHGIAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONGGIAOVIEN> PHANCONGGIAOVIENs { get; set; }
    }
}
