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
        public ActionResult Index(string search = "", string Sort = "MaSanPham", string Icon = "", int page = 1)
        {
            List<SanPham> sanPham = db.SanPhams.Where(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.Sort = Sort;
            ViewBag.Icon = Icon;
            if(Sort == "MaSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.MaSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.MaSanPham).ToList();
            }  
            else if(Sort == "TenSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.TenSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.TenSanPham).ToList();
            }
            else if(Sort == "KichThuoc")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.KichThuoc).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.KichThuoc).ToList();
            }
            else if(Sort == "Gia")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.Gia).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.Gia).ToList();
            }
            else if(Sort == "SoLuongKho")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.SoLuongKho).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.SoLuongKho).ToList();
            }
            else if(Sort == "MaLoaiSP")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.MaLoaiSP).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.MaLoaiSP).ToList();
            }
            int NoOfRecordPerPage = 5;
            double countFoods = sanPham.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countFoods) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPham = sanPham.Skip(NoOfSkip).Take(NoOfRecordPerPage).ToList();
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
            if(ModelState.IsValid)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index", "Product", "Admin");
            }    
            else
            {
                return RedirectToAction("Create");
            }    
        }
        public ActionResult Edit(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.MaSanPham == id).FirstOrDefault();
            List<LoaiSanPham> loaiSP = db.LoaiSanPhams.ToList();
            ViewBag.LoaiSP = loaiSP;
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(SanPham sp)
        {
            if (sp == null)
                return RedirectToAction("Index", "Product", "Admin");
            else
            {
                SanPham newSP = db.SanPhams.Where(row => row.MaSanPham == sp.MaSanPham).FirstOrDefault();
                newSP.MaLoaiSP = sp.MaLoaiSP;
                newSP.TenSanPham = sp.TenSanPham;
                newSP.Gia = sp.Gia;
                newSP.KichThuoc = sp.KichThuoc;
                newSP.SoLuongKho = sp.SoLuongKho;
                newSP.HinhAnh = sp.HinhAnh;
                newSP.MoTa = sp.MoTa;
                db.SaveChanges();
                return RedirectToAction("Index", "Product", "Admin");
            }    
        }
        public ActionResult Delete(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.MaSanPham == id).FirstOrDefault();
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index", "Product", "Admin");
        }
    }
}