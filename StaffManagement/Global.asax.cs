using System.Data.Entity.Migrations;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using StaffManagement.Util;

namespace StaffManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var kernel = new StandardKernel(new NinjectRegistrations());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            kernel.Unbind<ModelValidatorProvider>();
            
#if DEBUG
            new DbMigrator(new Migrations.Configuration()).Update();
#endif
        }
    }
}