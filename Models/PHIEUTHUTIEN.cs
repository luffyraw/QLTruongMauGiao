namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("PHIEUTHUTIEN")]
    public partial class PHIEUTHUTIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTHUTIEN()
        {
            DONGCHIPHIs = new HashSet<DONGCHIPHI>();
        }

        [Key]
        [StringLength(5)]
        [DisplayName("Mã phiếu")]
        public string MaPhieu { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("Mã trẻ")]
        public string MaTre { get; set; }

        [DisplayName("Ngày lập phiếu")]
        public DateTime NgayLapPhieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONGCHIPHI> DONGCHIPHIs { get; set; }

        public virtual TRE TRE { get; set; }
    }
}
