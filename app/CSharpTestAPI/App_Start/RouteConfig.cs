using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Swashbuckle.Application;

namespace CSharpTestAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("favicon.ico");

            routes.MapMvcAttributeRoutes();

            routes.MapHttpRoute("swagger_root", "", null, null,
                new RedirectHandler(message => message.RequestUri.ToString(), "swagger"));
        }
    }
}