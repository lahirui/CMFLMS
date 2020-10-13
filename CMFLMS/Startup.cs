using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMFLMS.Startup))]
namespace CMFLMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
