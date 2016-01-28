using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeFinder.WebForms.Employees
{
    using EmployeeFinder.Common;
    using EmployeeFinder.Data;
    using EmployeeFinder.Models;

    public partial class Search : System.Web.UI.Page
    {
        private readonly EmployeeFinderData data = new EmployeeFinderData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User == null || !this.User.Identity.IsAuthenticated)
            {
                this.Server.Transfer("~/Account/Login.aspx", true);
            }

            if (!this.IsPostBack)
            {
                
                
                var employees = this.data.Employees.All().OrderBy(x => x.Rating).ToList();
                this.ListViewEmployees.DataSource = employees;
                this.Page.DataBind();
                
            }
        }

        protected void btnSortByPosition_OnClick(object sender, EventArgs e)
        {
            var employees = this.data.Employees.All().OrderBy(x => x.Position).ToList();
            this.ListViewEmployees.DataSource = employees;
            this.Page.DataBind();
        }

        protected void SearchBtn_OnClick(object sender, EventArgs e)
        {
            var search = this.SearchBox.Text.Split(
                new char[]
                    {
                        ' '
                    },
                StringSplitOptions.RemoveEmptyEntries);
            var firstName = search[0].ToLower();
            var lastName = search[1].ToLower();
            var employees = this.data.Employees.All().Where(x => x.FirstName.ToLower() == firstName && x.LastName.ToLower() == lastName).ToList();
            this.ListViewEmployees.DataSource = employees;
            this.Page.DataBind();
        }
    }
}