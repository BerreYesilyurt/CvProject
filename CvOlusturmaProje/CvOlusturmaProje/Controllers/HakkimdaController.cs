using CvOlusturmaProje.Models.Entity;
using CvOlusturmaProje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvOlusturmaProje.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<Tbl_Hakkimda> repo = new GenericRepository<Tbl_Hakkimda>();
        // GET: Hobi

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Hakkimda p)
        {
            //Tbl_Hobilerim t = new Tbl_Hobilerim();
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Resim = p.Resim;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);

            return RedirectToAction("Index");


        }
    }
}