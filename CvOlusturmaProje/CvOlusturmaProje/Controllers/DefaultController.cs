using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvOlusturmaProje.Models.Entity;

namespace CvOlusturmaProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities(); // DbCvEntities sınıfından db adında bir nesne türetildi.
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkimda.ToList(); // Hakkımda tablosunda yer alan değerleri listele.


            return View(degerler); // Geriye değerleri döndürüyoruz.
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.tbl_SosyalMedya.Where(x=>x.Durum==true).ToList(); 

            return PartialView(sosyalmedya); // View tarafında birden fazla bölme yapılması gerekiyorsa kullanılır.
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimlerim.ToList();

            return PartialView(deneyimler); // View tarafında birden fazla bölme yapılması gerekiyorsa kullanılır.
        }

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.Tbl_Eğitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.Tbl_Yeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobiler = db.Tbl_Hobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifikalarim()
        {
            var sertifikalar = db.Tbl_Sertifikalarım.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
            

        [HttpPost]
        public PartialViewResult Iletisim(Tbl_Iletisim t)
        {
            t.Tarih = DateTime.Parse( DateTime.Now.ToShortDateString());
            db.Tbl_Iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}