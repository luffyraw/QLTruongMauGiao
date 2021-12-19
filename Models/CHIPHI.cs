namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHIPHI")]
    public partial class CHIPHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHIPHI()
        {
            DONGCHIPHIs = new HashSet<DONGCHIPHI>();
        }

        [Key]
        [StringLength(5)]
        [DisplayName("Mã chi phí")]
        public string MaChiPhi { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Nội dung")]
        public string NoiDung { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Đơn giá")]
        public decimal DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONGCHIPHI> DONGCHIPHIs { get; set; }
    }
}
