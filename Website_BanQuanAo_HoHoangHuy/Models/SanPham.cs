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
        [Required]
        public string TenSanPham { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required]
        public Nullable<float> Gia { get; set; }

        [Required]
        public string KichThuoc { get; set; }
        public string MoTa { get; set; }

        [Required]
        public Nullable<int> SoLuongKho { get; set; }
        public string HinhAnh { get; set; }
        [Required]
        public int MaLoaiSP { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}