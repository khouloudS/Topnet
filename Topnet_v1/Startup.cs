using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Topnet_v1.Startup))]
namespace Topnet_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
