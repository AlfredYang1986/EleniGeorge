using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EleniGeorge.Models;

namespace EleniGeorge.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Landing

        public ActionResult Landing()
        {
            return View();
        }

        // GET: /Index

        public ActionResult Index()
        {
            var m = new HomeIndexModel();

            return View(m);
        }

        // GET: /SignInView

        public ActionResult SignInView()
        {
            return View();
        }

        // GET: /Profile

        public ActionResult Profile()
        {
            return View();
        }

        // POST: /Search

        [HttpPost]
        public ActionResult Search(string strBrand)
        {
            //return PartialView();
            return null;
        }

        public ActionResult ProductDetail(int itemID)
        {
            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
