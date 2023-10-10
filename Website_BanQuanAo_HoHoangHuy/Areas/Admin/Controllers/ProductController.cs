using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanQuanAo_HoHoangHuy.Models;

namespace Website_BanQuanAo_HoHoangHuy.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: Admin/Product
        public ActionResult Index(string search = "")
        {
            List<SanPham> sanPham = db.SanPhams.Where(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(sanPham);
        }
        public ActionResult Detail(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.MaSanPham == id).FirstOrDefault();
            if (sp == null)
                return RedirectToAction("Index", "Product", "Admin");
            return View(sp);
        }
        public ActionResult Create()
        {
            List<LoaiSanPham> loaiSP = db.LoaiSanPhams.ToList();
            ViewBag.LoaiSP = loaiSP;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            if (sp == null)
                return View();
            else
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index", "Product", "Admin");
            }    
        }
    }
}