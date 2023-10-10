using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website_BanQuanAo_HoHoangHuy.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }
        public Nullable<DateTime> NgayMua { get; set; }
        public string KhachHang { get; set; }
        public Nullable<float> TongTien { get; set; }
        public string TrangThaiDonHang { get; set; }
    }
}