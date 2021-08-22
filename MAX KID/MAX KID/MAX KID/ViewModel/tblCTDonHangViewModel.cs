using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MAX_KID.ViewModel
{
    public class tblCTDonHangViewModel
    {
        [Key]
        public int ID_TaiKhoan { get; set; }

        public int ID_Quyen { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

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

        public int ID_ChiTietDonHang { get; set; }

        public int ID_DonHang { get; set; }

        public int ID_SanPham { get; set; }

        public int soluong { get; set; }

        public int dongia { get; set; }

    }
}