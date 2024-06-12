using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_LTW_HVC.Models;

namespace DOAN_LTW_HVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult error404()
        {
            return View();
        }
    }
}