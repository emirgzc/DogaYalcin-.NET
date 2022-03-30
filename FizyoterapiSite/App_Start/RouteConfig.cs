using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FizyoterapiSite
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Slider", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Blog",
				url: "{controller}/{action}/{id}/{Title}",
				defaults: new
				{
					controller = "Blog",
					action = "BlogDetails",
					id = UrlParameter.Optional,
					Title = UrlParameter.Optional
				});

			routes.MapRoute(
				name: "Services",
				url: "{controller}/{action}/{id}/{Title}",
				defaults: new
				{
					controller = "Services",
					action = "ServicesDetails",
					id = UrlParameter.Optional,
					Title = UrlParameter.Optional
				});
		}
	}
}
