// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Erzasoft.Web;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Erzasoft.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.RegisterAutofac(app);
            ConfigureAuth(app);
        }
    }
}
