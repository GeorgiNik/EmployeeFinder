using EmployeeFinder.WebForms;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EmployeeFinder.WebForms
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}