using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deneme.Models.Entity;
namespace Deneme.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Stok_TakipEntities ent = new Stok_TakipEntities();
        public ActionResult Index()
        {
            List<SelectListItem> degerler = (from i in ent.MUSTERILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MUSTERIAD,
                                                 Value = i.MUSTERIID.ToString()
                                             }).ToList();
            ViewBag.ktg = degerler;
            return View();
        }
        [HttpGet]
        public ActionResult SatisYap()
        {
           


            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SATISLAR s)
        {
            var ktg = ent.MUSTERILER.Where(m => m.MUSTERIID == s.MUSTERILER.MUSTERIID).FirstOrDefault();
            s.MUSTERILER = ktg;

            // ------- Satış Yapıldığında var olan stok sayısından satılan adet kadar düşsün
            var urun = ent.URUNLER.FirstOrDefault(x=>x.URUNID==s.URUN);
            urun.STOK = Convert.ToByte((urun.STOK - s.ADET));
            // --------
            ent.SATISLAR.Add(s);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}