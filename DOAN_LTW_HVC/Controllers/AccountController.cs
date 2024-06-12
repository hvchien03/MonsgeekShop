using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_LTW_HVC.Models;
using DOAN_LTW_HVC.ViewModel;
using DOAN_LTW_HVC.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Policy;
using DOAN_LTW_HVC.Filters;

namespace DOAN_LTW_HVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [MyAuthentication]
        public ActionResult index(string username = "")
        {
            var app_dbContext = new App_DBContext();
            AppUser user = app_dbContext.Users.Where(t => t.UserName == username).FirstOrDefault();
            return View(user);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rvm)
        {
            if(ModelState.IsValid)
            {
                var appDBCpntext = new App_DBContext();
                var userStore = new AppUserStore(appDBCpntext);
                var userManager = new AppUserManager(userStore);
                var passwdHash = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.Username,
                    PasswordHash = passwdHash,
                    DIACHI = rvm.Address,
                    PhoneNumber = rvm.PhoneNumber
                };
                IdentityResult identityResult = userManager.Create(user);
                if(identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }    
                return RedirectToAction("Index", "Home");
            }   
            else
            {
                ModelState.AddModelError("New Errol", "Invalid Data");
                return View();
            }    
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM lvm)
        {
            var appDBCpntext = new App_DBContext();
            var userStore = new AppUserStore(appDBCpntext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user != null) {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if(userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new {area = "Admin"});
                }else if(userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager"});
                }
                else 
                {
                    return RedirectToAction("Index", "Home");
                }    
            }else
            {
                ModelState.AddModelError("Myerrol", "Invalid Username and Password");
                return View();
            }    
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}