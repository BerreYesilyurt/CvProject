using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvOlusturmaProje.Repositories;
using CvOlusturmaProje.Models.Entity;

namespace CvOlusturmaProje.Controllers
{
    public class HobiController : Controller
    {

        GenericRepository<Tbl_Hobilerim> repo = new GenericRepository<Tbl_Hobilerim>();
        // GET: Hobi

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Hobilerim p)
        {
            //Tbl_Hobilerim t = new Tbl_Hobilerim();
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);

            return RedirectToAction("Index");

 
        }
    }
}