using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;    //1

namespace MVCStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities(); //2
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]   //3
        public ActionResult YeniSatis() 
        {
            return View();
        }   
        
        [HttpPost]  //4
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}