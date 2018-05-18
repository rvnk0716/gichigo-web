using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myWebSite.Startup))]
namespace myWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
