using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            //var degerler = db.TBLMUSTERILER.ToList();
            //return View(degerler);

            //Searching
            var degerler = from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            //Değer kontrolü
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var mst = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(mst);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Sayfalar arası veri taşıma
        public ActionResult MusteriGetir(int id)
        {
            var mst = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mst);
        }

        //Güncelleme
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}