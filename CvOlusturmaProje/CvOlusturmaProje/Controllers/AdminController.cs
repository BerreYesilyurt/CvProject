using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvOlusturmaProje.Models.Entity;
using CvOlusturmaProje.Repositories;


namespace CvOlusturmaProje.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        GenericRepository<Tbl_Admin> repo = new GenericRepository<Tbl_Admin>();
        // GET: Admin
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        //Aynı fonksiyonu hem HttpGet hem de HttpPost metodu ile kullanabiliyoruz.
        [HttpGet]
        public ActionResult AdminEkle() // Burada da view ekledik. Bu view'in adı da DeneyimEkle.cshtml. Bu da ayrı bir ekleme sayfasıdır.
        {
            return View();

        }


        [HttpPost]
        public ActionResult AdminEkle(Tbl_Admin p) // Tbl_Deneyimlerim tablosundan bir p parametresi alıyor.
        {
            repo.TAdd(p); // p parametresini DeneyimRepository sınıfındaki TAdd fonksiyonunu kullanarak ekle.

            return RedirectToAction("Index"); // Yukarıda yazdığımız Index fonksiyonunu döndür. Yani yeni bir deneyim ekledikten sonra otomatik olarak tekrar listelenmesini komut olarak döndürüyor.
        }

        public ActionResult AdminSil(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            return View(t);


        }



        [HttpPost]
        public ActionResult AdminDuzenle(Tbl_Admin p)
        {
            Tbl_Admin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre= p.Sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");


        }
    }
}