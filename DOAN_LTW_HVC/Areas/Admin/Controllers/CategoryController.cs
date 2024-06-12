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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        DB_Context db = new DB_Context();
        public ActionResult Index()
        {
            List<LOAISANPHAM> lst = db.LoaiSanPhams.ToList();
            return View(lst);
        }
    }
}