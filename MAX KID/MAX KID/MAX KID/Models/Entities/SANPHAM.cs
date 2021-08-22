namespace MAX_KID.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }

        [Key]
        public int ID_SanPham { get; set; }

        public int? ID_LoaiSP { get; set; }

        public int? ID_HangSX { get; set; }

        [Required]
        [StringLength(100)]
        public string ImgLink { get; set; }

        [Required]
        [StringLength(250)]
        public string TenSanPham { get; set; }

        [Required]
        [StringLength(250)]
        public string ThongSoKiThuat { get; set; }

        [Required]
        [StringLength(100)]
        public string DoTuoiSuDung { get; set; }

        public int GiaSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual HANGSX HANGSX { get; set; }

        public virtual LOAISP LOAISP { get; set; }
    }
}
