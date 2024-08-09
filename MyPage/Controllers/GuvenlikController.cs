using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPage.Models;
using System.Web.Security;


namespace MyPage.Controllers
{
    public class GuvenlikController : BaseController
    {
                       
        // GET: Guvenlik
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanıcı_Giris t)
        {
            var bilgiler = db.Kullanıcı_Giris.FirstOrDefault(x=>x.kullanıcıAd == t.kullanıcıAd && x.sifre == t.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanıcıAd, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
                           
        }
    }
}