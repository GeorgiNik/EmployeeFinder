using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeFinder.WebForms.Startup))]
namespace EmployeeFinder.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
