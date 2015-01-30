using Hovis.Web.Base;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Hovis.Web.Base
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IdentityConfig.ConfigureAuth(app);
        }
    }
}