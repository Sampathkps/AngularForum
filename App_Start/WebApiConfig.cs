using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AngularForum
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "GetAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "forum", action = "GetAllForum", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "AddAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "forum", action = "AddForum", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetSingleAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "forum", action = "GetForum", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "UpdateAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "forum", action = "UpdateForum", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DeleteAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "forum", action = "DeleteForum", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
