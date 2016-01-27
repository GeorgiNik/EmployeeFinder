using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFinder.Data
{
    using EmployeeFinder.Data.Repositories;
    using EmployeeFinder.Models;

    public interface IEmployeeFinderData
    {
        IRepository<Comment> Comments { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Company> Companies { get; }
        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
