using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Website_BanQuanAo_HoHoangHuy.ViewModel;
using Website_BanQuanAo_HoHoangHuy.Models;
using Website_BanQuanAo_HoHoangHuy.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Helpers;

namespace Website_BanQuanAo_HoHoangHuy.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            var AppDbContext = new AppDbContext();
            var userStore = new AppUserStore(AppDbContext);
            var userManager = new AppUserManager(userStore);

            AppUser user = userManager.FindById(User.Identity.GetUserId());
            return View(user);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid || register.Password != null)
            {
                var AppDbContext = new AppDbContext();
                var userStore = new AppUserStore(AppDbContext);
                var userManager = new AppUserManager(userStore);

                var passwordHash = Crypto.HashPassword(register.Password);

                var user = new AppUser();
                user.Name = register.Name;
                user.UserName = register.Username;
                user.Email = register.Email;
                user.PhoneNumber = register.PhoneNumber;
                user.PasswordHash = passwordHash;

                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                }
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            var AppDbContext = new AppDbContext();
            var userStore = new AppUserStore(AppDbContext);
            var userManager = new AppUserManager(userStore);
            if(login.Username == null)
                return View();
            var user = userManager.Find(login.Username, login.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
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