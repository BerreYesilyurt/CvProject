using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvOlusturmaProje.Repositories;
using CvOlusturmaProje.Models.Entity;

namespace CvOlusturmaProje.Controllers
{
    [Authorize] // attribute. Controllerın üzerine yazmamızın sebebi Eğitim controllerında bulunan bütün metotları kapsayabilmesidir.
    public class EgitimController : Controller
    {
        GenericRepository<Tbl_Eğitimlerim> repo = new GenericRepository<Tbl_Eğitimlerim>();
        // GET: Egitim
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }


        [HttpGet]
        public ActionResult EgitimEkle()
        {

            return View();

        }

        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Eğitimlerim p)
        {

            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);

            return RedirectToAction("Index");

        }


        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(Tbl_Eğitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }

            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.Baslik = t.Baslik;
            egitim.AltBaslik1 = t.AltBaslik1;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.Tarih = t.Tarih;
            egitim.GNO = t.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}