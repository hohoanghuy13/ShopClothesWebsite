using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanQuanAo_HoHoangHuy.Models;

namespace Website_BanQuanAo_HoHoangHuy.Controllers
{
    public class ProductController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: Product
        public ActionResult Index(string search = "", string Sort = "TenSanPham", string Icon = "", int page = 1)
        {
            List<SanPham> sanPham = db.SanPhams.Where(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.Sort = Sort;
            ViewBag.Icon = Icon;
            if (Sort == "TenSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.TenSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.TenSanPham).ToList();
            }
            if(Sort == "Gia")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.Gia).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.Gia).ToList();
            }
            int NoOfRecordPerPage = 4;
            double countProducts = sanPham.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countProducts) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPham = sanPham.Skip(NoOfSkip).Take(NoOfRecordPerPage).ToList();
            return View(sanPham);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            else
            {
                SanPham sp = db.SanPhams.Where(row => row.MaSanPham == id).FirstOrDefault();
                return View(sp);
            }    
        }
        [HttpPost]
        public ActionResult AddToCart(ChiTietHoaDon sp, HoaDon hd)
        {
            if (hd.KhachHang != null)
            {
                HoaDon hoaDonCuaKH = db.HoaDons.Where(row => row.KhachHang == hd.KhachHang && row.TrangThaiDonHang == "Chưa thanh toán").FirstOrDefault();
                ChiTietHoaDon themVaoGio = new ChiTietHoaDon();

                List<HoaDon> lastBill = db.HoaDons.ToList();
                if (lastBill.Count == 0)
                    hoaDonCuaKH.MaHoaDon = 1;
                else
                    hoaDonCuaKH.MaHoaDon = lastBill.Count + 1;
                if (hoaDonCuaKH == null)
                {
                    hoaDonCuaKH.KhachHang = hd.KhachHang;
                    hoaDonCuaKH.NgayMua = DateTime.Now.Date;
                    hoaDonCuaKH.TongTien = 0;
                    hoaDonCuaKH.TrangThaiDonHang = "Chưa thanh toán";
                    db.HoaDons.Add(hoaDonCuaKH);
                    db.SaveChanges();
                }
                hoaDonCuaKH = db.HoaDons.Where(row => row.KhachHang == hd.KhachHang && row.TrangThaiDonHang == "Chưa thanh toán").FirstOrDefault();
                themVaoGio.MaHoaDon = hoaDonCuaKH.MaHoaDon;
                themVaoGio.MaSanPham = sp.MaSanPham;
                themVaoGio.SoLuong = sp.SoLuong;
                themVaoGio.Gia = sp.Gia;
                themVaoGio.ThanhTien = sp.SoLuong * sp.Gia;
                hoaDonCuaKH.TongTien += themVaoGio.ThanhTien;
                db.ChiTietHoaDons.Add(themVaoGio);
                db.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Index");
        }
        public ActionResult T_Shirt()
        {
            List<SanPham> sanPham = db.SanPhams.Where(row => row.MaLoaiSP == 1).ToList();
            return View(sanPham);
        }
        public ActionResult Shirt()
        {
            List<SanPham> sanPham = db.SanPhams.Where(row => row.MaLoaiSP == 2).ToList();
            return View(sanPham);
        }
        public ActionResult Polo()
        {
            List<SanPham> sanPham = db.SanPhams.Where(row => row.MaLoaiSP == 3).ToList();
            return View(sanPham);
        }
    }
}