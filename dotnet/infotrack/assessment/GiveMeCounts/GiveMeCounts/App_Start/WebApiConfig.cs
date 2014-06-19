using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GiveMeCounts
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
               name: "Data",
               routeTemplate: "api/data/get_count",
               defaults: new { controller = "data", action = "GetCount" }
            );
        }
    }
}
