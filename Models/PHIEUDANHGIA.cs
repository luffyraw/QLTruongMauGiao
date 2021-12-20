namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("PHIEUDANHGIA")]
    public partial class PHIEUDANHGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDANHGIA()
        {
            KETQUADANHGIAs = new HashSet<KETQUADANHGIA>();
        }

        [Key]
        [StringLength(5)]
        [DisplayName("Mã phiếu")]
        public string MaPhieu { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("Mã trẻ")]
        public string MaTre { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("Mã giáo viên")]
        public string MaGV { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [DisplayName("Năm học")]
        public int NamHoc { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUADANHGIA> KETQUADANHGIAs { get; set; }

        public virtual TRE TRE { get; set; }
    }
}
