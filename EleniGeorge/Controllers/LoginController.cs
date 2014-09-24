using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EleniGeorge.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login?username={username}&password={password}

        public JsonResult Login(string username, string password)
        {
            var reVal = username == "Yang" && password == "Yuan";
            return Json(reVal, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoginWithFaceBook(string token)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: /LoginWithAdministrator?username={username}&password={password}

        public JsonResult LoginWithAdministrator(string username, string password)
        {
            var reVal = username == "Yang" && password == "Yuan";
            return Json(reVal, JsonRequestBehavior.AllowGet);
        }
    }
}
