namespace MAX_KID.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }

        [Key]
        public int ID_DonHang { get; set; }

        public int? ID_TaiKhoan { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaylap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaynhanhang { get; set; }

        [StringLength(150)]
        public string diachigiaohang { get; set; }

        [StringLength(16)]
        public string sodienthoai { get; set; }

        [StringLength(250)]
        public string hotenkhachhang { get; set; }

        public bool? trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
