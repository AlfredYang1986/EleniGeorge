﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;

namespace EleniGeorge.Models
{
    public class CategoryModel
    {
        private IEnumerable<string> _categories;

        public CategoryModel()
        {
            string strPath = Path.Combine(HostingEnvironment.MapPath("~/Config"), @"Tags.xml");
            XDocument _doc = XDocument.Load(strPath);

            _categories = from el in _doc.Descendants("Category")
                          select string.Format("{0}", el.Attribute("value").Value);
        }

        public IEnumerable<string> categories
        {
            get 
            {
                return _categories;
            }
        }
    }
}