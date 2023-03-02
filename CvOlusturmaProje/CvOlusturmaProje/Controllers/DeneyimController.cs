using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvOlusturmaProje.Repositories;
using CvOlusturmaProje.Models.Entity;

namespace CvOlusturmaProje.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository repo = new DeneyimRepository(); // Buraya DeneyimRepository'i verdik. O da GenericRepository'den miras alıyor. Bu sayede GenericRepository'de yazdığımız ekleme, silme vb. gibi işlevleri buradan yapabilme imkanı vardır.
        // GET: Deneyim
        public ActionResult Index() // Index sayfasına view ekledik. Bu view Deneyim klasörü altında yer alan Index.cshtml. Burada deneyimle ilgili olan fonksiyonları yazdık.
        {
            var degerler = repo.List();
            return View(degerler);
        }

        //Aynı fonksiyonu hem HttpGet hem de HttpPost metodu ile kullanabiliyoruz.
        [HttpGet]
        public ActionResult DeneyimEkle() // Burada da view ekledik. Bu view'in adı da DeneyimEkle.cshtml. Bu da ayrı bir ekleme sayfasıdır.
        {
            return View();

        }


        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimlerim p) // Tbl_Deneyimlerim tablosundan bir p parametresi alıyor.
        {
            repo.TAdd(p); // p parametresini DeneyimRepository sınıfındaki TAdd fonksiyonunu kullanarak ekle.

            return RedirectToAction("Index"); // Yukarıda yazdığımız Index fonksiyonunu döndür. Yani yeni bir deneyim ekledikten sonra otomatik olarak tekrar listelenmesini komut olarak döndürüyor.
        }

        public ActionResult DeneyimSil(int id)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);


        }



        [HttpPost]
        public ActionResult DeneyimGetir(Tbl_Deneyimlerim p)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");


        }

    }
}