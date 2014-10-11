using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Web.Hosting;

namespace EleniGeorge.Models
{
    public class ColorModel
    {
        private IEnumerable<string> _colors;

        public ColorModel()
        {
            string strPath = Path.Combine(HostingEnvironment.MapPath("~/Config"), @"Tags.xml");
            XDocument _doc = XDocument.Load(strPath);

            _colors = from el in _doc.Descendants("Color")
                          select string.Format("{0}", el.Attribute("value").Value);
        }

        public IEnumerable<string> colors
        {
            get 
            {
                return _colors;
            }
        }
    }
}