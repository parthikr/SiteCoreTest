using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebExperience.Test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //  config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
