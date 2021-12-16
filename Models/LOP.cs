namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOP")]
    public partial class LOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOP()
        {
            PHANCONGGIAOVIENs = new HashSet<PHANCONGGIAOVIEN>();
            TREs = new HashSet<TRE>();
        }

        [Key]
        [StringLength(5)]
        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên lớp")]
        public string TenLop { get; set; }
        [DisplayName("Sĩ số")]
        public int SiSo { get; set; }
        [DisplayName("Độ tuổi")]
        public int DoTuoi { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Khối")]
        public string Khoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONGGIAOVIEN> PHANCONGGIAOVIENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRE> TREs { get; set; }
    }
}
