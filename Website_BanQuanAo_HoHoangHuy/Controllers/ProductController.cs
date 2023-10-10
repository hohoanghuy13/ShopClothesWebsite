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
            double countFoods = sanPham.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countFoods) / Convert.ToDouble(NoOfRecordPerPage)));
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