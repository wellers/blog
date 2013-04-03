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
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute( "IndexByMonth", "Home/Index/{month}/{year}",
				new { controller = "Home", action="Index", month = UrlParameter.Optional, year = UrlParameter.Optional });

			routes.MapRoute("IndexByID", "Home/IndexByID/{id}",
				new { controller = "Home", action = "IndexByID", id = UrlParameter.Optional });

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