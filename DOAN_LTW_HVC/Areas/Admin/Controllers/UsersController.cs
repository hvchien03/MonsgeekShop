using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_LTW_HVC.Identity;
using DOAN_LTW_HVC.Filters;
using System.Web.Helpers;
using DOAN_LTW_HVC.ViewModel;
using Microsoft.AspNet.Identity;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace DOAN_LTW_HVC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    [MyAuthentication]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            App_DBContext dbContext = new App_DBContext();
            List<AppUser> users = dbContext.Users.ToList();
            return View(users);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(RegisterVM rvm)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("New Errol", "Invalid Data");
                return View();
            }    
        }
        public ActionResult update(string UserName)
        {
            var appDBCpntext = new App_DBContext();
            var userStore = new AppUserStore(appDBCpntext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.FindByName(UserName);
            var viewModel = new UpdateVM
            {
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.DIACHI
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult update(UpdateVM updateVM)
        {
            var appDBCpntext = new App_DBContext();
            var userStore = new AppUserStore(appDBCpntext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.FindByName(updateVM.Username);
            if (user != null)
            {
                user.Email = updateVM.Email;
                user.DIACHI = updateVM.Address;
                user.PhoneNumber = updateVM.PhoneNumber;
                userManager.Update(user);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string UserName)
        {
            var appDBCpntext = new App_DBContext();
            var userStore = new AppUserStore(appDBCpntext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.FindByName(UserName);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(string UserName, string diachi)
        {
            var appDBCpntext = new App_DBContext();
            var userStore = new AppUserStore(appDBCpntext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.FindByName(UserName);
            userManager.Delete(user);

            return RedirectToAction("Index");
        }

    }
}