using System.Web.Http;


namespace refactor_me
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

              config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/products/{id}/{controller}/{id1}",
                defaults: new { id1 = RouteParameter.Optional }
            );
        }
    }
}
