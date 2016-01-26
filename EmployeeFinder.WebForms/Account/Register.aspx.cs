using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EmployeeFinder.Models;
namespace EmployeeFinder.WebForms.Account
{
    using System.Web.Security;

    using EmployeeFinder.WebForms.Controls.Notifier;

    using EmployeeFinder.Common;
    using EmployeeFinder.Models;

    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new User()
            {
                UserName = this.Email.Text,
                Email = this.Email.Text,
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                Rating = 0,
                AvatarUrl = GlobalConstants.DefaultUserAvatar
            };
            IdentityResult result = manager.Create(user, this.Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // string code = manager.GenerateEmailConfirmationToken(user.Id);
                // string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                // manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                if (!Roles.RoleExists("user"))
                {
                    Roles.CreateRole("user");
                }
                Roles.AddUserToRole(user.UserName, "user");
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                Notifier.Error(result.Errors.FirstOrDefault());
            }
        }
    }
}