namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

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
        [DisplayName("Mã giáo viên")]
        public string MaGV { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên giáo viên")]
        public string TenGV { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Quê quán")]
        public string QueQuan { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Số điện thoại")]
        public string DienThoai { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Loại hợp đồng")]
        public string LoaiHopDong { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Lương")]
        public decimal Luong { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Kinh nghiệm")]
        public string KinhNghiem { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Trình độ")]
        public string TrinhDo { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Chuyên ngành")]
        public string ChuyenNganh { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Loại tốt nghiệp")]
        public string LoaiTotNghiep { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Tên tài khoản")]
        public string TenTK { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDANHGIA> PHIEUDANHGIAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONGGIAOVIEN> PHANCONGGIAOVIENs { get; set; }
    }
}
