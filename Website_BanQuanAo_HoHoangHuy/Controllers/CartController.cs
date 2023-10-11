using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanQuanAo_HoHoangHuy.Models;

namespace Website_BanQuanAo_HoHoangHuy.Controllers
{
    public class CartController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: Cart
        public ActionResult Index()
        {
            List<ChiTietHoaDon> cthd = db.ChiTietHoaDons.Where(row => row.MaHoaDon == 1).ToList();
            return View(cthd);
        }
    }
}