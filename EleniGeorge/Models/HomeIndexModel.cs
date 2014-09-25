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
            items = new ItemGalleryModel();
        }

        public SiderBarModel siderbar;
        public ItemGalleryModel items;
    }
}