using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deneme.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Deneme.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Stok_TakipEntities ent = new Stok_TakipEntities();

        public ActionResult Index()
        {
            //string search,int sayfaNo=1

            //var sonuc2 = from d in ent.URUNLER select d;

            //if (!string.IsNullOrEmpty(search))
            //{
            //    degerler2 = degerler2.Where(m=>m.URUNAD.Contains(search));
            //}
            //var degerler = ent.URUNLER.ToList().ToPagedList(sayfaNo,4);
            var degerler = ent.URUNLER.ToList();
            return View(degerler);

            //return View(ent.URUNLER.Where(x => x.URUNAD.Contains(search) || search == null).ToList().ToPagedList(sayfaNo, 4));

            //if (!string.IsNullOrEmpty(search))
            //{
            //    var Sonuc1 = ent.URUNLER.ToList().Where(m => m.URUNAD.Contains(search)).ToPagedList(sayfaNo, 4);
            //    return View(Sonuc1);
            //}
            //var Sonuc2 = ent.URUNLER.ToList().ToPagedList(sayfaNo, 4);
            //return View(Sonuc2);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in ent.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.ktg = degerler;                                  
                                           
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(URUNLER u)
        {
           
            var ktg = ent.KATEGORILER.Where(m => m.KATEGORIID == u.KATEGORILER.KATEGORIID).FirstOrDefault();
            u.KATEGORILER = ktg;
            ent.URUNLER.Add(u);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var urun = ent.URUNLER.Find(id);
            ent.URUNLER.Remove(urun);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> degerler = (from i in ent.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.ktg = degerler;
            var getir = ent.URUNLER.Find(id);
            return View("UrunGuncelle", getir);
        
        }
        [HttpPost]
        public ActionResult UrunGuncelle(URUNLER k)
        {
        
            KATEGORILER kategoriler = new KATEGORILER();
            var guncelle = ent.URUNLER.Find(k.URUNID);
            guncelle.URUNAD = k.URUNAD;
            guncelle.MARKA = k.MARKA;
            var ktg = ent.KATEGORILER.Where(m => m.KATEGORIID == k.KATEGORILER.KATEGORIID).FirstOrDefault();

           guncelle.URUNKATEGORI = ktg.KATEGORIID;
            guncelle.FIYAT = k.FIYAT;
            guncelle.STOK = k.STOK;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}