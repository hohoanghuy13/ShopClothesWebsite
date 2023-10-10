using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website_BanQuanAo_HoHoangHuy.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
    }
}