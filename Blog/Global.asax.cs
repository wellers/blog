using System.Web.Mvc;
using System.Web.Routing;

namespace Blog
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			//filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("Error - 404", "NotFound", new {controller = "Error", action = "NotFound"});
			routes.MapRoute("Error - 500", "ServerError", new { controller = "Error", action = "ServerError" });

			routes.MapRoute("Archive", "Home/Archive/{year}/{month}", 
				new { controller = "Home", action = "Archive", year = UrlParameter.Optional, month = UrlParameter.Optional });
			
			routes.MapRoute("Post", "Home/BlogEntry/ID/{id}",
				new { controller = "Home", action = "BlogEntry", id = UrlParameter.Optional });

			routes.MapRoute("Tag", "Home/Tag/{tag}",
				new { controller = "Home", action = "Tag", tag = UrlParameter.Optional });

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