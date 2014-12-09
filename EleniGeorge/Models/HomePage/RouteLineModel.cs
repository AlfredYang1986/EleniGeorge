using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EleniGeorge.Models.HomePage
{
    public class RouteNode 
    {
        public string href { get; set; }
        public string value { get; set; }
    }

    public class RouteLineModel
    {
        public IEnumerable<RouteNode> routes { get; set; }
    }
}