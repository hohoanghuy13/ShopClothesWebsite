using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website_BanQuanAo_HoHoangHuy.Models
{
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Nullable<float> Gia { get; set; }
        public string KichThuoc { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> SoLuongKho { get; set; }
        public string HinhAnh { get; set; }
        public int MaLoaiSP { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}