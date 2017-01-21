using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_17MinApp.Startup))]
namespace _17MinApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
