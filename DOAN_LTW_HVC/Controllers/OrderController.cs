using DOAN_LTW_HVC.Identity;
using DOAN_LTW_HVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_LTW_HVC.Filters;

namespace DOAN_LTW_HVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        DB_Context db = new DB_Context();
        [MyAuthentication]
        public ActionResult Index()
        {
            string username = getUsername();
            List<DONHANG> dh = db.DONHANGs.Where(t => t.Username == username).ToList();
            return View(dh);
        }
        public ActionResult order()
        {
            string username = getUsername();
            List<GIOHANG> lst = db.GioHangs.Where(t => t.username == username).ToList();
            return View(lst);
        }//a hoan nhìn nè
        [HttpPost]
        public ActionResult order(string PayMethod)
        {
            string username = getUsername();
            List<GIOHANG> gh = db.GioHangs.Where(t => t.username == username).ToList();
            if (PayMethod == "Thanh toán bằng ví momo")
            {
                foreach (GIOHANG item in gh)
                {
                    DONHANG dh = new DONHANG();
                    dh.MAGH = item.MAGH;
                    dh.TIME = DateTime.Now;
                    dh.PHUONGTHUC = "Thanh toán bằng ví momo";
                    dh.MASP = item.MASP;
                    dh.SL = item.SL;
                    dh.Username = username;
                    dh.TINHTRANG = "Chưa duyệt";
                    dh.THANHTIEN = item.ToTal;
                    db.DONHANGs.Add(dh);
                    GIOHANG i = db.GioHangs.Where(t => t.MAGH == dh.MAGH).FirstOrDefault();
                    db.GioHangs.Remove(i);
                    db.SaveChanges();
                }
            }
            else
            {
                foreach (GIOHANG item in gh)
                {
                    DONHANG dh = new DONHANG();
                    dh.MAGH = item.MAGH;
                    dh.TIME = DateTime.Now;
                    dh.PHUONGTHUC = "Thanh toán khi nhận hàng";
                    dh.MASP = item.MASP;
                    dh.SL = item.SL;
                    dh.Username = username;
                    dh.TINHTRANG = "Chưa duyệt";
                    dh.THANHTIEN = item.ToTal;
                    db.DONHANGs.Add(dh);
                    GIOHANG i = db.GioHangs.Where(t => t.MAGH == dh.MAGH).FirstOrDefault();
                    db.GioHangs.Remove(i);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public string getUsername()
        {
            var appDbContext = new App_DBContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser appUser = userManager.FindById(User.Identity.GetUserId());
            return (appUser == null) ? "" : appUser.UserName;
        }
    }
}