using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BanQuanAo_HoHoangHuy.Models;
using Website_BanQuanAo_HoHoangHuy.Filter;

namespace Website_BanQuanAo_HoHoangHuy.Areas.Admin.Controllers
{
    [AdminAuthorFilter]
    public class CategoryController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<LoaiSanPham> loaiSP = db.LoaiSanPhams.ToList();
            ViewBag.LoaiSP = loaiSP;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoaiSanPham loaiSP)
        {
            if (loaiSP == null)
                return View();
            else
            {
                db.LoaiSanPhams.Add(loaiSP);
                db.SaveChanges();
                return RedirectToAction("Index", "Category", "Admin");
            }
        }
        public ActionResult Edit(int id)
        {
            LoaiSanPham loaiSP = db.LoaiSanPhams.Where(row => row.MaLoaiSP == id).FirstOrDefault();
            return View(loaiSP);
        }
        [HttpPost]
        public ActionResult Edit(LoaiSanPham loaiSP)
        {
            if (loaiSP == null)
                return RedirectToAction("Index", "Category", "Admin");
            else
            {
                LoaiSanPham newLoaiSP = db.LoaiSanPhams.Where(row => row.MaLoaiSP == loaiSP.MaLoaiSP).FirstOrDefault();
                newLoaiSP.TenLoaiSP = loaiSP.TenLoaiSP;
                db.SaveChanges();
                return RedirectToAction("Index", "Category", "Admin");
            }
        }
        public ActionResult Delete(int id)
        {
            LoaiSanPham loaiSP = db.LoaiSanPhams.Where(row => row.MaLoaiSP == id).FirstOrDefault();
            db.LoaiSanPhams.Remove(loaiSP);
            db.SaveChanges();
            return RedirectToAction("Index", "Category", "Admin");
        }

    }
}