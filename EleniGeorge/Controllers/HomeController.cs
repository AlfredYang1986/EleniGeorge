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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EleniGeorge.Entity;
using System.Linq.Expressions;

namespace EleniGeorge.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Landing

        public ActionResult Landing()
        {
            var m = new AccountModel();
            m.isLandingPage = true;

            return View(m);
        }

        // GET: /Index

        public ActionResult Index(string keywords = "")
        {
            var m = new HomeIndexModel();

            using (var db = new TTDBEntities())
            {
                IEnumerable<Item> result = db.Item;
                m.items = Item2ItemModel(SearchWithInput(keywords, result));
            }

            ViewBag.searchInput = keywords;
            /************************************************************************/
            /* for test                                                             */
            /* add login                                                            */
            /************************************************************************/
            m.account = new AccountModel()
            {
                screenName = "Alfred",
                isLandingPage = false,
                isLogedIn = true
            };
            return View(m);
        }

        // GET: /SignInView

        public ActionResult SignInView()
        {
            var m = new AccountModel();
            return View(m);
        }

        // GET: /Profile

        public ActionResult Profile()
        {
            var m = new AccountModel();
            return View(m);
        }

        private ItemGalleryModel Item2ItemModel(IEnumerable<Item> result)
        {
            return new ItemGalleryModel(
                    (from it in result let firstOrDefault = it.ItemPicture.FirstOrDefault(x => x.IsDefault)
                     where firstOrDefault != null
                     select new GalleryItem()
                     {
                        Name = it.Name,
                        ImgUrl = firstOrDefault.Picture.LargePictureAddress,
                        Price = it.ListPrice.HasValue ? it.ListPrice.Value : 0.0
                     }).ToList()
                );
        }

        private IEnumerable<Item> SearchWithInput(string input, IEnumerable<Item> reVal)
        {
            /************************************************************************/
            /* 4.1 find category                                                    */
            /************************************************************************/
            var result = reVal;
            var cat_candi = new CategoryModel();
            if (cat_candi.categories.Any(x => x.ToLower() == input.ToLower()))
            {
                result = from it in result
                         where it.Category.Any(x => x.Category1.ToLower() == input.ToLower())
                         select it;
            }

            /************************************************************************/
            /* 4.2 find color                                                       */
            /************************************************************************/
            var col_candi = new ColorModel();
            if (col_candi.colors.Any(x => x.ToLower() == input.ToLower()))
            {
                result = from it in result
                         where it.Color.Any(x => x.ColorName.ToLower() == input.ToLower())
                         select it;
            }

            return result;
        }

        // POST: /Search

        [HttpPost]
        public ActionResult Search(string data)
        {
            dynamic searchData = JsonConvert.DeserializeObject(data);

            using (var db = new TTDBEntities())
            {
                IEnumerable<Item> result = db.Item;
                /************************************************************************/
                /* 1. Category                                                          */
                /************************************************************************/
                JArray catArrTmp = searchData.cats;
                var catArr = from it in catArrTmp
                             select new string(it.ToString().ToCharArray());

                foreach (var cat in catArr)
                {
                    result = from it in result
                             where it.Category.Any(x => x.Category1.ToLower() == cat.ToLower())
                             select it;
                }

                /************************************************************************/
                /* 2. Color                                                             */
                /************************************************************************/
                JArray colArr_tmp = searchData.colors;
                var colArr = from it in colArr_tmp
                             select new string(it.ToString().ToCharArray());

                foreach (var col in colArr)
                {
                    result = from it in result
                             where it.Color.Any(x => x.ColorName.ToLower() == col.ToLower())
                             select it;
                }

                /************************************************************************/
                /* 3. Size                                                              */
                /************************************************************************/
                JArray sizeArr_tmp = searchData.sizes;
                var sizeArr = from it in sizeArr_tmp
                              select new string(it.ToString().ToCharArray());

                foreach (var size in sizeArr)
                {
                    result = from it in result
                             where it.ItemSize.Any(x => x.Size.SizeName.ToString().ToLower() == size.ToLower())
                             select it;
                }
                /************************************************************************/
                /* 4.1 find category                                                    */
                /************************************************************************/
                string input = searchData.input;
                var cat_candi = new CategoryModel();
                if (cat_candi.categories.Any(x => x.ToLower() == input.ToLower()))
                {
                    result = from it in result
                             where it.Category.Any(x => x.Category1.ToLower() == input.ToLower())
                             select it;
                }

                /************************************************************************/
                /* 4.2 find color                                                       */
                /************************************************************************/
                var col_candi = new ColorModel();
                if (col_candi.colors.Any(x => x.ToLower() == input.ToLower()))
                {
                    result = from it in result
                             where it.Color.Any(x => x.ColorName.ToLower() == input.ToLower())
                             select it;
                }
                return PartialView("_IndexItemGallery", 
                    this.Item2ItemModel(result));
            }
        }

        public ActionResult ProductDetail(int itemID)
        {
            return null;
        }

        // Get: /PayPalPayment

        public async Task<ActionResult> PayPalPayment(double price)
        {
            var approvalUrl = await PayPalPaymentFacad.createPayment(price.ToString(), @"Alfred Test"
                                        , @"http://localhost:1053/Home/ConfirmPayment"
                                        , @"http://localhost:1053/Home/CancelPayment");
            return Redirect(approvalUrl);
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
            model.account = new AccountModel();
            return View("ShoppingBag", model);
        }

        // Get: /ListOrders?ClientID={id}

        public ActionResult ListOrders(string ClientID)
        {
            var model = new OrdersModel(ClientID);
            model.account = new AccountModel();
            return View("ListOrders", model);
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

        public ActionResult addToBag(string itmeID, string clientID)
        {
            return ShoppingBag(clientID);
        }

        public ActionResult SaveForLater(string itemID, string clientID)
        {
            return ListOrders(clientID);
        }
    }
}
