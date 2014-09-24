using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;

namespace EleniGeorge.Models
{
    public class SizeModel
    {
        private IEnumerable<string> _sizes;

        public SizeModel()
        {
            string strPath = Path.Combine(HostingEnvironment.MapPath("~/Config"), @"Tags.xml");
            XDocument _doc = XDocument.Load(strPath);

            _sizes = from el in _doc.Descendants("Size")
                          select string.Format("{0}", el.Attribute("value").Value);
        }

        public IEnumerable<string> sizes
        {
            get 
            {
                return _sizes;
            }
        }
    }
}