using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvOlusturmaProje.Models.Entity;
using CvOlusturmaProje.Repositories;

namespace CvOlusturmaProje.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<tbl_SosyalMedya> repo = new GenericRepository<tbl_SosyalMedya>();

        // GET: SosyalMedya
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }


        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }



        [HttpPost]
        public ActionResult SosyalMedyaEkle(tbl_SosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }


        [HttpPost]
        public ActionResult SayfaGetir(tbl_SosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.Durum = true;
            hesap.Link = p.Link;
            hesap.Simge = p.Simge;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaSil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");

        }
    }
}