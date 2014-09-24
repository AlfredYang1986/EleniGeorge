using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EleniGeorge.Models
{
    public class SiderBarModel
    {
        public CategoryModel catetegories;
        public SizeModel sizes;
        public ColorModel colors;

        public SiderBarModel()
        {
            catetegories = new CategoryModel();
            sizes = new SizeModel();
            colors = new ColorModel();
        }
    }
}