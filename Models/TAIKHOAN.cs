namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            GIAOVIENs = new HashSet<GIAOVIEN>();
            PHUHUYNHs = new HashSet<PHUHUYNH>();
        }

        [Key]
        [Required(ErrorMessage = "Không được để trống tên tài khoản")]
        [StringLength(20)]
        [DisplayName("Tên tài khoản")]
        public string TenTK { get; set; }

        [Required(ErrorMessage = "Không được để trống mật khẩu")]
        [StringLength(30)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Phân quyền")]
        public string PhanQuyen { get; set; }
        [DisplayName("Trạng thái hoạt động")]

        public bool TrangThaiHD { get; set; }

        [Required(ErrorMessage = "Không được để trống ảnh đại diện")]
        [StringLength(30)]

        [DisplayName("Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAOVIEN> GIAOVIENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHUHUYNH> PHUHUYNHs { get; set; }
    }
}
