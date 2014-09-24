using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EleniGeorge.Models
{
    public class HomeIndexModel
    {
        public HomeIndexModel()
        {
            siderbar = new SiderBarModel();
        }

        public SiderBarModel siderbar;
    }
}