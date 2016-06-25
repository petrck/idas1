// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the MvcApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Web;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
