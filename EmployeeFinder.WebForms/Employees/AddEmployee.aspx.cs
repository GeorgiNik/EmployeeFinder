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
    using EmployeeFinder.WebForms.Controls.Notifier;

    using Microsoft.AspNet.Identity;

    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User == null || !this.User.Identity.IsAuthenticated)
            {
                Server.Transfer("~/Account/Login.aspx", true);
            }



            if (!IsPostBack)
            {
                foreach (int value in Enum.GetValues(typeof(Position)))
                {
                    this.Possition.Items.Add(new ListItem(Enum.GetName(typeof(Position), value), value.ToString()));
                }
                foreach (int value in Enum.GetValues(typeof(Rating)))
                {
                    this.Rating.Items.Add(new ListItem(Enum.GetName(typeof(Rating), value), value.ToString()));
                }

                this.Rating.SelectedIndex = 0;

                var db = new EmployeeFinderData();




                Page.DataBind();
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            var uow = new EmployeeFinderData();

            var currentUser = uow.Users.All().FirstOrDefault(x => x.UserName == this.User.Identity.Name);
            var newEmployee = new Employee();
            newEmployee.FirstName = this.FirstName.Text;
            //newEmployee.Comments.Add();
            newEmployee.LastName = this.LastName.Text;
            newEmployee.Position = (Position)Enum.Parse(typeof(Position), this.Possition.SelectedValue);
            newEmployee.Rating = (Rating)Enum.Parse(typeof(Rating), this.Rating.SelectedValue);


            if (this.FileUploadImage.HasFile)
            {
                if (this.FileUploadImage.PostedFile.ContentLength > 1024000)
                {
                    Notifier.Error("File has to be less than 1MB");
                    return;
                }
                else
                {
                    string fileName = this.FileUploadImage.PostedFile.FileName;
                    var fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
                    var newName = Guid.NewGuid() + fileExtension;
                    this.FileUploadImage.SaveAs(Server.MapPath(GlobalConstants.ImagesPath + newName));

                    newEmployee.EmployeePhoto = newName;
                }
            }
            else if (this.ControlImageUrl.HaveUrl())
            {
                var imageName = Guid.NewGuid().ToString();
                var filePath = Server.MapPath(GlobalConstants.ImagesPath + imageName);
                var extension = this.ControlImageUrl.DownloadRemoteImageFile(filePath);
                imageName = imageName + '.' + extension;
                newEmployee.EmployeePhoto = imageName;
            }
            else
            {
                newEmployee.EmployeePhoto = GlobalConstants.DefautlBarterImg;
            }

            uow.Employees.Add(newEmployee);
            currentUser.Comments.Add(new Comment { Content = this.Comment.Text, Employee = newEmployee });
            uow.SaveChanges();
            Notifier.Success("Employee offer successfully created");
            Response.Redirect("~/Employees/AddEmployee");


        }
    }
}
