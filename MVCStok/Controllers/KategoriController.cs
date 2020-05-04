using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
	public class KategoriController : Controller
	{
		// GET: Kategori
		MvcDbStokEntities db = new MvcDbStokEntities(); //Entity'mizden db nesnesi oluşturduk
		public ActionResult Index()
		{
			var degerler = db.TBLKATEGORILER.ToList();      //db nesnemizden TBLKATEGORILER tablomuzu aldık ve listeye dönüştürdük, degerler değişkenine atadık
			return View(degerler);  //degerler değişkenimizi view sayfamıza dönderdik
		}
		

		//Eğer kullanıcı YeniKategoriye tıklasaydı fakat hiçbirşey yapmasaydı otomatik null kayıt girmiş olurdu HttpGet ve HttpPost ile bunun önüne geçiyoruz 
		[HttpGet]	//Eğer backend'de bir post işlemi vs yapmaz, sadece sayfayı yüklersek bunu yap. 
		public ActionResult YeniKategori()
		{
			return View();
		}


		[HttpPost]	//Sayfada bir post işlemi yapıldığı zaman işlemi gerçekleştir
		public ActionResult YeniKategori(TBLKATEGORILER p1) //Yeni Kategori eklemede p1 kullanalım. Silme de p2, güncellemede p3 vs kullanabiliriz
		{
			//Değer kontrolü
			if (!ModelState.IsValid)
			{
				return View();
			}

			db.TBLKATEGORILER.Add(p1);	//TBLKATEGORILER'in içerisine p1'den gelecek değerleri ekle(p1den gelecek değerler işin View tarafında yapılıyor)
			db.SaveChanges();	//Değişiklikleri kaydet.
			return View();		//Sayfayı geri dönder
		}

		public ActionResult Sil(int id)
		{
			var kategori = db.TBLKATEGORILER.Find(id);
			db.TBLKATEGORILER.Remove(kategori);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult KategoriGetir(int id)
		{
			var ktgr = db.TBLKATEGORILER.Find(id);
			return View("KategoriGetir", ktgr);
		}

		//Tanımladığımız Guncelle ActiionResult'u KategoriGetir.cshtml'deki @using (Html.BeginForm("Guncelle" ile aynı olmalı
		public ActionResult Guncelle(TBLKATEGORILER p1)
		{
			var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
			ktg.KATEGORIAD = p1.KATEGORIAD;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}