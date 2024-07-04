using System.Web.Mvc;
using System.Web.Routing;

namespace Blog
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("Error - 404", "NotFound", new { controller = "Error", action = "NotFound" });
			routes.MapRoute("Error - 500", "ServerError", new { controller = "Error", action = "ServerError" });

			routes.MapRoute("ArchiveByYearAndMonth", "archive/{year}/{month}",
				new { controller = "Home", action = "Archive", year = UrlParameter.Optional, month = UrlParameter.Optional });

			routes.MapRoute("ArchiveByYear", "archive/{year}",
				new { controller = "Home", action = "Archive", year = UrlParameter.Optional });

			routes.MapRoute("Post", "posts/{id}/{title}",
				new { controller = "Home", action = "BlogEntry", id = UrlParameter.Optional, title = UrlParameter.Optional });

			routes.MapRoute("Tag", "tags/{tag}",
				new { controller = "Home", action = "Tag", tag = UrlParameter.Optional });

			routes.MapRoute("About", "about", new { controller = "Home", action = "About" });
			routes.MapRoute("Contact", "contact", new { controller = "Home", action = "Contact" });

			routes.MapRoute("PostFeed", "feed/{type}", new { controller = "Home", action = "PostFeed", type = "rss" });

			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}
	}
}