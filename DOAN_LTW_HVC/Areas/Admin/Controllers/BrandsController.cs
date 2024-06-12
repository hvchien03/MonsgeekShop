using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_LTW_HVC.Models;
using DOAN_LTW_HVC.Filters;

namespace DOAN_LTW_HVC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    [MyAuthentication]
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        DB_Context db = new DB_Context();
        public ActionResult Index()
        {
            List<THUONGHIEU> lst = db.ThuongHieus.ToList();
            return View(lst);
        }
    }
}