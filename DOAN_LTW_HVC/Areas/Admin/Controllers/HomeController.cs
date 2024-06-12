using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_LTW_HVC.Filters;

namespace DOAN_LTW_HVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [MyAuthentication]
        [AdminAuthorization]
        public ActionResult Index()
        {
            return View();
        }
    }
}