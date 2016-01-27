namespace EmployeeFinder.WebForms.Employees
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using EmployeeFinder.Common;
    using EmployeeFinder.Data;
    using EmployeeFinder.Models;
    using EmployeeFinder.WebForms.Controls.Notifier;

    public partial class AddEmployee : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User == null || !this.User.Identity.IsAuthenticated)
            {
                this.Server.Transfer("~/Account/Login.aspx", true);
            }

            if (!this.IsPostBack)
            {
                foreach (int value in Enum.GetValues(typeof(Position)))
                {
                    this.Possition.Items.Add(new ListItem(Enum.GetName(typeof(Position), value), value.ToString()));
                }

                for (var i = 1; i <= 6; i++)
                {
                    this.Rating.Items.Add(new ListItem(i.ToString()));
                }

                this.Rating.SelectedIndex = 0;

                var db = new EmployeeFinderData();

                this.Page.DataBind();
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            var uow = new EmployeeFinderData();

            var currentUser = uow.Users.All().FirstOrDefault(x => x.UserName == this.User.Identity.Name);
            var newEmployee = new Employee();
            newEmployee.FirstName = this.FirstName.Text;
            newEmployee.LastName = this.LastName.Text;
            newEmployee.Position = (Position)Enum.Parse(typeof(Position), this.Possition.SelectedValue);
            newEmployee.Rating = this.Rating.SelectedIndex + 1;

            if (this.FileUploadImage.HasFile)
            {
                if (this.FileUploadImage.PostedFile.ContentLength > 1024000)
                {
                    Notifier.Error("File has to be less than 1MB");
                    return;
                }
                var fileName = this.FileUploadImage.PostedFile.FileName;
                var fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
                var newName = Guid.NewGuid() + fileExtension;
                this.FileUploadImage.SaveAs(this.Server.MapPath(GlobalConstants.ImagesPath + newName));

                newEmployee.EmployeePhoto = newName;
            }
            else if (this.ControlImageUrl.HaveUrl())
            {
                var imageName = Guid.NewGuid().ToString();
                var filePath = this.Server.MapPath(GlobalConstants.ImagesPath + imageName);
                var extension = this.ControlImageUrl.DownloadRemoteImageFile(filePath);
                imageName = imageName + '.' + extension;
                newEmployee.EmployeePhoto = imageName;
            }
            else
            {
                newEmployee.EmployeePhoto = GlobalConstants.DefaultUserAvatar;
            }

            uow.Employees.Add(newEmployee);
            currentUser.Comments.Add(new Comment { Content = this.Comment.Text, Employee = newEmployee });
            uow.SaveChanges();
            Notifier.Success("Employee offer successfully created");
            this.Response.Redirect("~/Employees/AddEmployee");
        }
    }
}