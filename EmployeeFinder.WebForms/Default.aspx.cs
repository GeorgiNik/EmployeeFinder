namespace EmployeeFinder.WebForms
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using EmployeeFinder.Data;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uow = new EmployeeFinderData();
            if (Cache["usersCount"] != null)
            {
                this.TotalUsers.Text = "Registered Users: " + Cache["usersCount"].ToString();
            }
            else
            {
                var usersCount = uow.Users.All().Count();
                Cache.Insert("usersCount", usersCount, null, DateTime.Now.AddSeconds(50), TimeSpan.Zero);
                this.TotalUsers.Text = "Registered Users: " + usersCount;
            }

            if (Cache["categoriesCount"] != null)
            {
                this.TotalEmployees.Text = "Total employees: " + Cache["employeesCount"].ToString();
            }
            else
            {
                var employeesCount = uow.Employees.All().Count();
                Cache.Insert("employeesCount", employeesCount, null, DateTime.Now.AddSeconds(50), TimeSpan.Zero);
                this.TotalEmployees.Text = "Total employees: " + employeesCount;
            }

            var employees = uow.Employees.All().OrderBy(x => x.Rating ).ToList();
            this.ListViewEmployees.DataSource = employees;
            this.Page.DataBind();

        }
    }
}