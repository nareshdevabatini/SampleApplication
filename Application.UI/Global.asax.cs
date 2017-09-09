using Application.UI.CastleDI;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Application.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer container;

        public MvcApplication()
        {
            this.container =
                new WindsorContainer().Install(new DependencyInstaller());
        }

        public override void Dispose()
        {
            this.container.Dispose();
            base.Dispose();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Services.Replace(
               typeof(IHttpControllerActivator),
               new WindsorActivator(this.container));
        }
    }
}
