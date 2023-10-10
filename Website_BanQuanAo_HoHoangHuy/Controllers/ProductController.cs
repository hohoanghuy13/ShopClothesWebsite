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
        public ActionResult Index()//Hien thi tat ca san pham - truyen vao string search
        {
            List<SanPham> sanPham = db.SanPhams.ToList();//Them chuc nang tim kiem
            return View(sanPham);
        }
    }
}