using eCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;// FormAuteh可用來做表單驗證，此類別是在System.Web.Security類別下

namespace eCMS.Controllers
{
    public class LoginController : Controller
    {
        NorthwindEntities1 db = new NorthwindEntities1();

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return Redirect("~/Home/Index");
            else
            {
                ViewBag.Title = "Login";
                return View();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                var CheckUser = db.User.Where(m => m.UserName == Username && m.Password == Password);
                if (!string.IsNullOrEmpty(CheckUser.ToString()))
                {
                    // 表單驗證服務，授權指定的帳號
                    FormsAuthentication.RedirectFromLoginPage(Username, true);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.Err = "帳密錯誤!";
                }
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();   // 登出
            return RedirectToAction("Index", "Login");
        }

    }
}