using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website_BanQuanAo_HoHoangHuy.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<float> Gia { get; set; }
        public Nullable<float> ThanhTien { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}