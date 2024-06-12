using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_LTW_HVC.Models;
using DOAN_LTW_HVC.Filters;
using DOAN_LTW_HVC.Identity;
using Microsoft.AspNet.Identity;

namespace DOAN_LTW_HVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        DB_Context db = new DB_Context();
        [MyAuthentication]
        public ActionResult Index(string username)
        {
            username = getUsername();
            ViewBag.Username = username;
            List<GIOHANG> lst = db.GioHangs.Where(t => t.username == username).ToList();
            if (lst.Count == 0)
            {
                return View("NoItem");
            }
            else
            {
                return View(lst);
            }
        }
        public int tinhTT(string username)
        {
            username = getUsername();
            List<GIOHANG> lst = db.GioHangs.Where(t => t.username == username).ToList();
            int tongtien = 0;
            foreach (GIOHANG item in lst)
            {
                tongtien += item.ToTal;
            }
            return tongtien;
        }
        [HttpPost]
        public ActionResult Add(int id = 0)
        {
            string username = getUsername();
            SANPHAM p = db.SanPhams.Where(row => row.MASP == id).FirstOrDefault();
            GIOHANG cartItem = db.GioHangs.Where(row => row.MASP == id && row.username == username).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.SL += 1;
            }
            else
            {
                GIOHANG cart = new GIOHANG();
                cart.MASP = id;
                cart.price = p.GIA;
                cart.username = username;
                cart.SL = 1;
                db.GioHangs.Add(cart);
            }
            db.SaveChanges();
            return RedirectToAction("Index", new { username });
        }
        [HttpPost]
        public ActionResult UpdateSL(int id = 0, int sl = 0)
        {
            string username = getUsername();
            if (sl > 0)
            {
                GIOHANG cartItem = db.GioHangs.Where(cart => cart.MASP == id && cart.username == username).FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.SL = sl;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { username });
        }
        [HttpPost]
        public ActionResult delete(int magh)
        {
            GIOHANG cartItem = db.GioHangs.Where(t => t.MAGH == magh).FirstOrDefault();
            if (cartItem != null)
            {
                db.GioHangs.Remove(cartItem);
                db.SaveChanges();
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
        //public ActionResult order(string username)
        //{
        //    username = getUsername();
        //    List<GIOHANG> lst = db.GioHangs.Where(t => t.username == username).ToList();
        //    return View(lst);
        //}//a hoan nhìn nè
        //[HttpPost]
        //public ActionResult order(string username, string PayMethod)
        //{
        //    username = getUsername();
        //    List<GIOHANG> gh = db.GioHangs.Where(t => t.username == username).ToList();
        //    if (PayMethod == "Thanh toán bằng ví momo")
        //    {
        //        foreach (GIOHANG item in gh)
        //        {
        //            DONHANG dh = new DONHANG();
        //            dh.MAGH = item.MAGH;
        //            dh.TIME = DateTime.Now;
        //            dh.PHUONGTHUC = "Thanh toán bằng ví momo";
        //            dh.MASP = item.MASP;
        //            dh.SL = item.SL;
        //            dh.Username = username;
        //            dh.TINHTRANG = "Chưa duyệt";
        //            dh.THANHTIEN = item.ToTal;
        //            db.DONHANGs.Add(dh);
        //            GIOHANG i = db.GioHangs.Where(t => t.MAGH == dh.MAGH).FirstOrDefault();
        //            db.GioHangs.Remove(i);
        //            db.SaveChanges();
        //        }
        //    }
        //    else
        //    {
        //        foreach (GIOHANG item in gh)
        //        {
        //            DONHANG dh = new DONHANG();
        //            dh.MAGH = item.MAGH;
        //            dh.TIME = DateTime.Now;
        //            dh.PHUONGTHUC = "Thanh toán khi nhận hàng";
        //            dh.MASP = item.MASP;
        //            dh.SL = item.SL;
        //            dh.Username = username;
        //            dh.TINHTRANG = "Chưa duyệt";
        //            dh.THANHTIEN = item.ToTal;
        //            db.DONHANGs.Add(dh);
        //            GIOHANG i = db.GioHangs.Where(t => t.MAGH == dh.MAGH).FirstOrDefault();
        //            db.GioHangs.Remove(i);
        //            db.SaveChanges();
        //        }
        //    }
        //    return RedirectToAction("Index", "Order");
        //}
    }
}