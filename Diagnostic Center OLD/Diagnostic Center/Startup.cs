using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Diagnostic_Center.Startup))]
namespace Diagnostic_Center
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
