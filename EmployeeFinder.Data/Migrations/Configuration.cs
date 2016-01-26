namespace EmployeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<EmployeeFinder.Data.EmployeeFinderDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;
            
        }

      
    }
}
