using ActivityProject.Utilities;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FizyoterapiSite.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        AdminLoginManager adm = new AdminLoginManager(new EfAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            string sifre = Sifrele.MD5Olustur(a.Password);
            var adminuserinfo = adm.GetAdmin(a.Username, sifre);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.Username, false);
                Session["Username"] = adminuserinfo.Username;
                return RedirectToAction("AAboutList", "About");
            }
            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre Yanlış";
            return View();
        }
        public ActionResult LogOutAd()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}