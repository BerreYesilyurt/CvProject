using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvOlusturmaProje.Models.Entity;
using CvOlusturmaProje.Repositories;

namespace CvOlusturmaProje.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim

        GenericRepository<Tbl_Iletisim> repo = new GenericRepository<Tbl_Iletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}