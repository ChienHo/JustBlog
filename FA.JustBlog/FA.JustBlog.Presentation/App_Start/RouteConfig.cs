using System.Web.Mvc;
using System.Web.Routing;

namespace FA.JustBlog.Presentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    "Posts",
            //    "Posts/{year}/{month}/{title}",
            //    new { controller = "Posts", action = "Details" },
            //    new { year = @"\d{4}", month = @"\d{2}" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Posts", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FA.JustBlog.Presentation.Controllers" }
            );
        }
    }
}