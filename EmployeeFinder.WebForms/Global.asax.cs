namespace EmployeeFinder.WebForms
{
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;

    using EmployeeFinder.WebForms.App_Start;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            DatabaseConfig.Initialize();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}