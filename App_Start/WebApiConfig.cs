using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由 => 屬性路由
            config.MapHttpAttributeRoutes();

            // Web API 路由 => 傳統路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
