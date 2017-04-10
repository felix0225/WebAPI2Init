using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication1.Formatters;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Replace Jil
            config.Formatters.Remove(config.Formatters.JsonFormatter);
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(new JilFormatter());

            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
