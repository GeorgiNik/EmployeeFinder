namespace EmployeeFinder.WebForms.Employees
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Common;

    using Data;

    using EmployeeFinder.Models;

    public partial class Details : Page
    {
        private readonly EmployeeFinderData data = new EmployeeFinderData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User == null || !this.User.Identity.IsAuthenticated)
            {
                this.Server.Transfer("~/Account/Login.aspx", true);
            }

            if (this.IsPostBack)
            {
                return;
            }

            var idStr = this.Context.Request.QueryString["id"];
            if (idStr == null)
            {
                return;
            }

            for (int i = 1; i <= 6; i++)
            {
                this.Rating.Items.Add(new ListItem(i.ToString()));
            }
            
            var id = int.Parse(idStr);
            var employee = this.data.Employees.All().FirstOrDefault(x => x.Id == id);
            this.Image1.ImageUrl = GlobalConstants.ImagesPath + employee.EmployeePhoto;
            this.lblFirstName.Text = employee.FirstName;
            this.lblLastName.Text = employee.LastName;
            this.lblPosition.Text = Enum.GetName(typeof(Position), employee.Position);
            this.lblRating.Text = Math.Round((decimal)employee.Rating / employee.RatingsCount, 2).ToString();

            this.lvComments.DataSource = employee.Comments;
            this.lvComments.DataBind();
        }

        protected void ButtonOnCommand(object sender, CommandEventArgs e)
        {
            var employeeId = int.Parse(this.Context.Request.QueryString["id"]);
            var employee = this.data.Employees.All().FirstOrDefault(x => x.Id == employeeId);
            var commentId = int.Parse(e.CommandArgument.ToString());

            var comment = employee.Comments.FirstOrDefault(x => x.Id == commentId);

            if (e.CommandName == "like")
            {
                comment.Likes++;
            }
            else if (e.CommandName == "dislike")
            {
                comment.Dislikes++;
            }

            this.data.SaveChanges();

            this.lvComments.DataSource = employee.Comments;
            this.lvComments.DataBind();
        }

        protected void btnRate_OnClick(object sender, EventArgs e)
        {
            var employeeId = int.Parse(this.Context.Request.QueryString["id"]);
            var employee = this.data.Employees.All().FirstOrDefault(x => x.Id == employeeId);
            employee.Rating += this.Rating.SelectedIndex + 1;
            employee.RatingsCount++;
            this.lblRating.Text = Math.Round((decimal)employee.Rating / employee.RatingsCount, 2).ToString();
            this.data.SaveChanges();
        }
    }
}