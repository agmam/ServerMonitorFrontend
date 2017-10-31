using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServerMonitorFrontend.Startup))]
namespace ServerMonitorFrontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
