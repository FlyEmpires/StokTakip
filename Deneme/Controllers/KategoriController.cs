using Deneme.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Deneme.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Stok_TakipEntities ent = new Stok_TakipEntities();

        public ActionResult Index()
        {
            var degerler = ent.KATEGORILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(KATEGORILER k)
        {
            if (!ModelState.IsValid) // Doğrulma işlemi yapılmadıysa 
            {
                return View("KategoriEkle");
            }
            ent.KATEGORILER.Add(k);
            ent.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = ent.KATEGORILER.Find(id);
            ent.KATEGORILER.Remove(kategori);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var getir = ent.KATEGORILER.Find(id);
            return View("KategoriGetir",getir);
        }
        public ActionResult Guncelle(KATEGORILER k)
        {
            var guncelle = ent.KATEGORILER.Find(k.KATEGORIID);
            guncelle.KATEGORIAD = k.KATEGORIAD;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}