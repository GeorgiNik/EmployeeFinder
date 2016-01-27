namespace EmployeeFinder.Data
{
    using System.Data.Entity;

    using EmployeeFinder.Data.Migrations;
    using EmployeeFinder.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class EmployeeFinderDbContext : IdentityDbContext<User>
    {
        public EmployeeFinderDbContext() : base("DefaultConnectionString")
        {
        }

        public static EmployeeFinderDbContext Create()
        {
            return new EmployeeFinderDbContext();
        }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<Company> Companies { get; set; } 

         
    }
}
