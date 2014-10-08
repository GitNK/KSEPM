using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using KSEPM.Web.App_Start;
using KSEPM.Web.Infrastructure;
using KSEPM.Web.Infrastructure.TypeMapping;

namespace KSEPM.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {  
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new AutoMapperConfigurator().Configure(WebContainerManager.GetAll<IAutoMapperTypeConfigurator>());
        }
    }
}
