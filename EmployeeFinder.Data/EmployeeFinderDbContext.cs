namespace EmployeeFinder.Data
{
    using System.Data.Entity;

    public class EmployeeFinderDbContext: DbContext
    {
        public EmployeeFinderDbContext() : base("DefaultConnectionString")
        {
        }

        public static EmployeeFinderDbContext Create()
        {
            return new EmployeeFinderDbContext();
        }
    }
}
