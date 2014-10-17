﻿using System;
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
        public ActionResult Search(string data)
        {
            //return PartialView();
            dynamic sd = JsonConvert.DeserializeObject(data);

            using (var db = new TTDBEntities())
            {
                IEnumerable<Item> result = db.Item;

                /************************************************************************/
                /* 1. Category                                                          */
                /************************************************************************/
                JArray catArr_tmp = sd.cats;
                var catArr = from it in catArr_tmp
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
                JArray colArr_tmp = sd.colors;
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
                JArray sizeArr_tmp = sd.sizes;
                var sizeArr = from it in sizeArr_tmp 
                             select new string(it.ToString().ToCharArray());

                foreach (var size in sizeArr)
                {
                    result = from it in result
                             where it.ItemSize.Any(x => x.Size.SizeName.ToString().ToLower() == size.ToLower())
                             select it;
                }

                /************************************************************************/
                /* 4. Search Input                                                      */
                /************************************************************************/
                string input = sd.input;

                /************************************************************************/
                /* 4.1 find category                                                    */
                /************************************************************************/
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

                var reVal = (from it in result
                             select new GalleryItem()
                             {
                                name = it.Name,
                                imgUrl = it.ItemPicture.FirstOrDefault(x => x.IsDefault)
                                            .Picture.LargePictureAddress,
                                price = it.ListPrice.HasValue ? it.ListPrice.Value : 0.0
                             }).ToList();

                return PartialView("_IndexItemGallery", new ItemGalleryModel(reVal));
            }
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
