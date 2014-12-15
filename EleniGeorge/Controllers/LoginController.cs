using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EleniGeorge.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EleniGeorge.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login?username={username}&password={password}

        [HttpPost]
        public JsonResult SignIn(string name, string pwd)
        {
            using (var db = new TTDBEntities())
            {
                var us = (from it in db.UserProfile
                          where it.UserName == name
                          select it).FirstOrDefault();

                var pd = (from itd in db.webpages_Membership
                          where itd.UserId == us.UserId
                          select itd.Password).FirstOrDefault();

                return loginReturn(pd.Equals(pwd), us.UserName);
            }
        }

        [HttpPost]
        public JsonResult CreatMemberShip(string name, string pwd)
        {
            try
            {
                using (var db = new TTDBEntities())
                {
                    if ((from it in db.UserProfile
                                  where it.UserName == name
                                  select it).Count() > 0)
                        return loginReturn(false, "");

                    var nUser = new UserProfile() { UserName = name, Email = pwd };
                    db.UserProfile.Add(nUser);
                    db.SaveChanges();
                    var nMem = new webpages_Membership() { Password = pwd, PasswordSalt = "", PasswordFailuresSinceLastSuccess = 0 };
                    nMem.UserId = nUser.UserId;
                    db.webpages_Membership.Add(nMem);
                    db.SaveChanges();

                    return loginReturn(true, name);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                return loginReturn(false, "");
            }
        }

        [HttpPost]
        public JsonResult LoginWithFaceBook(string fbID) //, string fbEmail = "")
        {
            using (var db = new TTDBEntities())
            {
                /************************************************************************/
                /* find if login previously                                             */
                /************************************************************************/
                var result = from it in db.webpages_OAuthMembership
                             where it.Provider == @"facebook" && it.ProviderUserId == fbID
                             select it.UserId;

                if (result.Count() == 0)
                {
                    var ad = new webpages_OAuthMembership()
                    {
                        Provider = @"facebook",
                        ProviderUserId = fbID
                    };

                    var au = new UserProfile()
                    {
                        UserName = fbID,
                        Email = fbID
                    };

                    db.UserProfile.Add(au);
                    db.SaveChanges();

                    ad.UserId = ad.UserId;
                    db.webpages_OAuthMembership.Add(ad);
                    db.SaveChanges();

                    return loginReturn(true, fbID);
                }
                else
                {
                    return loginReturn(true, (from iter in db.UserProfile
                                              where iter.UserId == result.FirstOrDefault()
                                              select iter.UserName).FirstOrDefault());
                }
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: /LoginWithAdministrator?username={username}&password={password}

        public JsonResult LoginWithAdministrator(string username, string password)
        {
            var reVal = username == "Yang" && password == "Yuan";
            return Json(reVal, JsonRequestBehavior.AllowGet);
        }

        private JsonResult loginReturn(Boolean bSuccess, String username)
        {
            dynamic reVal = new JObject();

            reVal.success = bSuccess;
            reVal.name = username;

            return Json(JsonConvert.SerializeObject(reVal), JsonRequestBehavior.AllowGet);
        }
    }
}
