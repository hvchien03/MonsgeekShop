using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_LTW_HVC.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.UI.WebControls;
using DOAN_LTW_HVC.Filters;
using System.Web.UI;

namespace DOAN_LTW_HVC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    [MyAuthentication]
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        DB_Context db = new DB_Context();
        public ActionResult Index(string search = "", int page = 1)
        {
            List<SANPHAM> sp = db.SanPhams.Where(t => t.TENSP.Contains(search)).ToList();
            ViewBag.search = search;
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.page = page;
            ViewBag.NoOfPages = NoOfPages;
            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(sp);
        }
        public ActionResult Loaisp(int loai = 1, int page = 1)
        {
            List<SANPHAM> sp = db.SanPhams.Where(t => t.MALOAI.ToString().Contains(loai.ToString())).ToList();
            ViewBag.loaisp = loai;
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.page = page;
            ViewBag.NoOfPages = NoOfPages;
            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(sp);
        }
        public ActionResult create()
        {
            List<THUONGHIEU> th = db.ThuongHieus.ToList();
            ViewBag.thuonghieu = th;
            List<LOAISANPHAM> loai = db.LoaiSanPhams.ToList();
            ViewBag.loai = loai;
            return View();
        }
        [HttpPost]
        public ActionResult create(SANPHAM p, HttpPostedFileBase imagefile)
        {
            if (ModelState.IsValid)
            {
                if (imagefile != null && imagefile.ContentLength > 0)
                {
                    if (imagefile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("DUONGDAN", "Kính thước file không được lớn hơn 2MB.");
                        return View();
                    }
                    var allewdExtensions = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imagefile.FileName).ToLower();
                    if (!allewdExtensions.Contains(fileEx))
                    {
                        ModelState.AddModelError("DUONGDAN", "Chỉ chấp nhận file PNG và JPG");
                        return View();
                    }
                    p.DUONGDAN = "";
                    db.SanPhams.Add(p);
                    db.SaveChanges();

                    SANPHAM pro = db.SanPhams.ToList().Last();
                    var filename = pro.MASP.ToString() + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), filename);
                    imagefile.SaveAs(path);

                    pro.DUONGDAN = filename;
                    db.SaveChanges();
                }
                else
                {
                    p.DUONGDAN = "";
                    db.SanPhams.Add(p);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult update(int id)
        {
            SANPHAM p = db.SanPhams.Where(t => t.MASP == id).FirstOrDefault();
            List<THUONGHIEU> th = db.ThuongHieus.ToList();
            ViewBag.thuonghieu = th;
            List<LOAISANPHAM> loai = db.LoaiSanPhams.ToList();
            ViewBag.loai = loai;
            return View(p);
        }
        [HttpPost]
        public ActionResult update(SANPHAM pro, HttpPostedFileBase imagefile)
        {
            SANPHAM p = db.SanPhams.Where(t => t.MASP == pro.MASP).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (imagefile != null && imagefile.ContentLength > 0)
                {
                    if (imagefile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("DUONGDAN", "Kính thước file không được lớn hơn 2MB.");
                        return View(p);
                    }
                    var allewdExtensions = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imagefile.FileName).ToLower();
                    if (!allewdExtensions.Contains(fileEx))
                    {
                        ModelState.AddModelError("DUONGDAN", "Chỉ chấp nhận file PNG và JPG");
                        return View(p);
                    }
                    string imagePath = Server.MapPath("~/Images/" + p.DUONGDAN);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    p.TENSP = pro.TENSP;
                    p.LAYOUT = pro.LAYOUT;
                    p.DUONGDAN = pro.DUONGDAN;
                    p.GIA = pro.GIA;
                    p.MOTA = pro.MOTA;
                    p.MATH = pro.MATH;
                    p.MALOAI = pro.MALOAI;
                    db.SaveChanges();

                    var filename = p.MASP.ToString() + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), filename);
                    imagefile.SaveAs(path);

                    p.DUONGDAN = filename;
                    db.SaveChanges();
                }
                else
                {
                    p.TENSP = pro.TENSP;
                    p.LAYOUT = pro.LAYOUT;
                    p.GIA = pro.GIA;
                    p.MOTA = pro.MOTA;
                    p.MATH = pro.MATH;
                    p.MALOAI = pro.MALOAI;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }
        public ActionResult delete(int id)
        {
            SANPHAM p = db.SanPhams.Where(t => t.MASP == id).FirstOrDefault();
            List<THUONGHIEU> th = db.ThuongHieus.ToList();
            ViewBag.thuonghieu = th;
            List<LOAISANPHAM> loai = db.LoaiSanPhams.ToList();
            ViewBag.loai = loai;
            return View(p);
        }
        [HttpPost]
        public ActionResult delete(SANPHAM pro)
        {
            SANPHAM p = db.SanPhams.Where(t => t.MASP == pro.MASP).FirstOrDefault();

            if (p != null)
            {
                if (p.DUONGDAN == "")
                {
                    db.SanPhams.Remove(p);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                string imagePath = Server.MapPath("~/Images/" + p.DUONGDAN);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                p.DUONGDAN = "";
                db.SanPhams.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}