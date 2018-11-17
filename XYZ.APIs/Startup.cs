using System.Web.Http;
using System.Web.OData.Extensions;
using XYZ.APIs;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace XYZ.APIs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.EnableDependencyInjection();
            ConfigureAuth(app);
        }
    }
}
