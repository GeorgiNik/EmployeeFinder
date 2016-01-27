namespace EmployeeFinder.WebForms.App_Start
{
    using System.Data.Entity;

    using EmployeeFinder.Data;
    using EmployeeFinder.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeFinderDbContext, Configuration>());
            EmployeeFinderDbContext.Create().Database.Initialize(true);
        }
    }
}