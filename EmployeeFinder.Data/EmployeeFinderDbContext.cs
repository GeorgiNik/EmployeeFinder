namespace EmployeeFinder.Data
{
    using System.Data.Entity;

    using EmployeeFinder.Data.Migrations;

    public class EmployeeFinderDbContext: DbContext
    {
        public EmployeeFinderDbContext() : base("DefaultConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeFinderDbContext, Configuration>());
        }

    }
}
