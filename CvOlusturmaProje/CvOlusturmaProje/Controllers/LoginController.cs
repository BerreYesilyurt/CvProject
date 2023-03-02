using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CvOlusturmaProje.Models.Entity;

namespace CvOlusturmaProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            DbCvEntities db = new DbCvEntities();
            var bilgi = db.Tbl_Admin.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre); // Eğer parametreler veri tabanındaki kullanıcı adı ve şifre ile uyumluysa yani null değerinden farklıysa
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index","Deneyim"); // Deneyim sayfasının Index'ine yönlendirir.
            }

            else
            {
                return RedirectToAction("Index", "Login"); // Yanlışsa giriş yapılamaz ve tekrar login sayfasında kalır.
            }
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}