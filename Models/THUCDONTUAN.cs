namespace QuanLyTruongMauGiao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("THUCDONTUAN")]
    public partial class THUCDONTUAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUCDONTUAN()
        {
            THUCDONNGAYs = new HashSet<THUCDONNGAY>();
        }

        [Key]
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(10)]
        public string MaTDT { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Column(TypeName = "date")]
        public DateTime NgayBD { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Column(TypeName = "date")]
        public DateTime NgayKT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUCDONNGAY> THUCDONNGAYs { get; set; }
    }
}
