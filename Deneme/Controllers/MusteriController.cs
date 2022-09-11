using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deneme.Models.Entity;

namespace Deneme.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        Stok_TakipEntities ent = new Stok_TakipEntities();

        public ActionResult Index()
        {
            var degerler = ent.MUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(MUSTERILER m)
        {
            ent.MUSTERILER.Add(m);
            ent.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = ent.MUSTERILER.Find(id);
            ent.MUSTERILER.Remove(musteri);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var guncelle = ent.MUSTERILER.Find(id);
            
            return View("MusteriGuncelle",guncelle);
        }
        [HttpPost]
        public ActionResult MusteriGuncelle(MUSTERILER m)
        {
            var guncelle = ent.MUSTERILER.Find(m.MUSTERIID);
            guncelle.MUSTERIAD = m.MUSTERIAD;
            guncelle.MUSTERISOYAD = m.MUSTERISOYAD;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}