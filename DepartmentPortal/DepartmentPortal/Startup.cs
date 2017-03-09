using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DepartmentPortal.Startup))]
namespace DepartmentPortal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
