namespace EmployeeFinder.WebForms.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;

    using EmployeeFinder.Common;
    using EmployeeFinder.Models;
    using EmployeeFinder.WebForms.Controls.Notifier;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new User
                           {
                               UserName = this.Email.Text,
                               Email = this.Email.Text,
                               FirstName = this.FirstName.Text,
                               LastName = this.LastName.Text,
                               AvatarUrl = GlobalConstants.DefaultUserAvatar
                           };
            var result = manager.Create(user, this.Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // string code = manager.GenerateEmailConfirmationToken(user.Id);
                // string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                // manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                IdentityHelper.SignIn(manager, user, false);
                if (!Roles.RoleExists("user"))
                {
                    Roles.CreateRole("user");
                }
                Roles.AddUserToRole(user.UserName, "user");
                IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
            }
            else
            {
                Notifier.Error(result.Errors.FirstOrDefault());
            }
        }
    }
}