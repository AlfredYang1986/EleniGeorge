using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EleniGeorge.Models;
using PayPalComponent;
using EleniGeorge.Models.ShoppingBag;
using EleniGeorge.Models.Orders;

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

        //public ActionResult Profile()
        //{
        //    return View();
        //}

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

        // Get: /PayPalPayment

        public async Task<ActionResult> PayPalPayment(double price)
        {
            var approal_url = await PayPalPaymentFacad.createPayment(price.ToString(), @"Alfred Test"
                                        , @"http://localhost:1053/Home/ConfirmPayment"
                                        , @"http://localhost:1053/Home/CancelPayment");
            return Redirect(approal_url);
        }

        // Get: /ConfirmPayment

        public async Task<string> ConfirmPayment(string token, string PayerID)
        {
            return await PayPalPaymentFacad.executePayment(token, PayerID);
        }

        // Get: /CancelPayment

        public ActionResult CancelPayment()
        {
            return null;
        }

        // Get: /ListAllPayments

        public async Task<string> ListAllPayments()
        {
            return await PayPalPaymentFacad.listAllPayments();
        }

        // Get: /ShoppingBag?ClientID={id}

        public ActionResult ShoppingBag(string ClientID)
        {
            var model = new ShoppingBagModel(ClientID);
            return View(model);
        }

        // Get: /ListOrders?ClientID={id}

        public ActionResult ListOrders(string ClientID)
        {
            var model = new OrdersModel(ClientID);
            return View(model);
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
