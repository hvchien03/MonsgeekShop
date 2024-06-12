using DOAN_LTW_HVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace DOAN_LTW_HVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        DB_Context db = new DB_Context();
        public ActionResult Index(string search = "", string sort = "", string layout = "", int page = 1)
        {
            List<SANPHAM> sp = db.SanPhams.Where(t => t.TENSP.Contains(search)).ToList();
            sp = sp.Where(t => t.LAYOUT.Contains(layout)).ToList();
            if (sp.Count == 0)
            {
                return View("NotFound");
            }
            else
            {
                ViewBag.layout = layout;
                ViewBag.search = search;
                ViewBag.sort1 = sort;
                //-----sort
                if (sort == "tang")
                {
                    ViewBag.sort = "Thấp đến cao";
                    sp = sp.OrderBy(t => t.GIA).ToList();
                }
                else
                {
                    ViewBag.sort = "Cao đến thấp";
                    sp = sp.OrderByDescending(t => t.GIA).ToList();
                }
                //-----paging
                int NoOfRecordPerPage = 12;
                int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
                int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
                ViewBag.page = page;
                ViewBag.NoOfPages = NoOfPages;
                sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
                return View(sp);
            }
        }
        public ActionResult Detail(int id)
        {
            SANPHAM sp = db.SanPhams.Where(t => t.MASP == id).FirstOrDefault();
            List<SANPHAM> lst = db.SanPhams.Where(t => t.LAYOUT == sp.LAYOUT).ToList();
            ViewBag.lst = lst;
            return View(sp);
        }
        public ActionResult Loaisp(int loai = 1, string sort = "tang", int page = 1)
        {
            List<SANPHAM> sp = db.SanPhams.Where(t => t.MALOAI.ToString().Contains(loai.ToString())).ToList();
            ViewBag.loai = loai;
            ViewBag.sort1 = sort;
            if (sort == "tang")
            {
                ViewBag.sort = "Thấp đến cao";
                sp = sp.OrderBy(t => t.GIA).ToList();
            }
            else
            {
                ViewBag.sort = "Cao đến thấp";
                sp = sp.OrderByDescending(t => t.GIA).ToList();
            }
            //-----paging
            int NoOfRecordPerPage = 12;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.page = page;
            ViewBag.NoOfPages = NoOfPages;
            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            if (loai == 4)
            {
                return View("Accessory", sp);
            }
            else
            {
                return View(sp);
            }
        }
    }
}