﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFinder.Data
{
    using System.Data.Entity;

    using EmployeeFinder.Data.Repositories;
    using EmployeeFinder.Models;

    public class EmployeeFinderData : IEmployeeFinderData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public EmployeeFinderData()
            : this(new EmployeeFinderDbContext())
        {
        }

        public EmployeeFinderData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

  

        public IRepository<Employee> Employees
        {
            get
            {
                return this.GetRepository<Employee>();
            }
        }

        public IRepository<Company> Companies
        {
            get
            {
                return this.GetRepository<Company>();
            }
        }
        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
