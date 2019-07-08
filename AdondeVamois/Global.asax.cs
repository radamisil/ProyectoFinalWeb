using Autofac.Integration.Mvc;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace AdondeVamois
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            var container = Dependencies.DependencyResolver.Setup();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            WebApiConfig.Container = container;
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // borrar cookie
        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if ((e.Context.Request.Url.AbsolutePath.ToLower().IndexOf("/content") != -1) || (e.Context.Request.Url.AbsolutePath.ToLower().IndexOf("/bundles") != -1))
            {
                e.Context.SkipAuthorization = true;
            }
        }
    }
}

