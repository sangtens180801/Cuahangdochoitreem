namespace MAX_KID.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDONHANG")]
    public partial class CTDONHANG
    {
        [Key]
        public int ID_ChiTietDonHang { get; set; }

        public int ID_DonHang { get; set; }

        public int ID_SanPham { get; set; }

        public int soluong { get; set; }

        public int dongia { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
