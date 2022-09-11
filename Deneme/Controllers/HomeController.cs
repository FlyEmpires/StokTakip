using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deneme.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Uygulamanın açıklama sayfası.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim Sayfan.";

            return View();
        }
        public ActionResult Test()
        {
            ViewBag.Message = "Bu bir test sayfasıdır.";

            return View();
        }
        public ActionResult Yardim()
        {
            return View();
        }
    }
}