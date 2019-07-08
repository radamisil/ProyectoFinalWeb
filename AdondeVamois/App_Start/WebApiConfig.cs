using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AdondeVamois.Dependencies;

namespace AdondeVamois
{
    public static class WebApiConfig
    {
        #region Fields
        public static IContainer Container { get; set; }
        #endregion

        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            if (Container == null)
            {
                Container = DependencyResolver.Setup();
            }
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}