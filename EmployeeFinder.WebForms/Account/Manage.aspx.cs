namespace EmployeeFinder.WebForms.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    using EmployeeFinder.Common;
    using EmployeeFinder.Data;
    using EmployeeFinder.WebForms.Controls.Notifier;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Manage : Page
    {
        protected string SuccessMessage { get; private set; }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(this.User.Identity.GetUserId());
        }

        protected void Page_Load()
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            // Enable this after setting up two-factor authentientication
            // PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;
            this.TwoFactorEnabled = manager.GetTwoFactorEnabled(this.User.Identity.GetUserId());

            this.LoginsCount = manager.GetLogins(this.User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!this.IsPostBack)
            {
                this.PopulateUserData();

                // Determine the sections to render
                if (this.HasPassword(manager))
                {
                    this.ChangePassword.Visible = true;
                }
                else
                {
                    this.CreatePassword.Visible = true;
                    this.ChangePassword.Visible = false;
                }

                // Render success message
                var message = this.Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    this.Form.Action = this.ResolveUrl("~/Account/Manage");

                    this.SuccessMessage = message == "ChangePwdSuccess"
                                              ? "Your password has been changed."
                                              : message == "SetPwdSuccess"
                                                    ? "Your password has been set."
                                                    : message == "RemoveLoginSuccess"
                                                          ? "The account was removed."
                                                          : message == "AddPhoneNumberSuccess"
                                                                ? "Phone number has been added"
                                                                : message == "RemovePhoneNumberSuccess"
                                                                      ? "Phone number was removed"
                                                                      : string.Empty;
                    Notifier.Success(this.SuccessMessage);
                }
            }
        }

        private void PopulateUserData()
        {
            var uow = new EmployeeFinderData();
            var userId = this.User.Identity.GetUserId();
            var user =
                uow.Users.All()
                    .Select(u => new { u.Id, u.FirstName, u.LastName, u.AvatarUrl })
                    .First(u => u.Id == userId);

            this.Avatar.ImageUrl = GlobalConstants.ImagesPath + user.AvatarUrl;

            this.Page.DataBind();

            this.FirstName.Text = user.FirstName;
            this.LastName.Text = user.LastName;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error);
            }
        }

        protected void UpdateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                var data = new EmployeeFinderData();
                var userId = this.User.Identity.GetUserId();
                var user = data.Users.Find(userId);

                if (this.FirstName.Text != user.FirstName)
                {
                    user.FirstName = this.FirstName.Text;
                }

                if (this.LastName.Text != user.LastName)
                {
                    user.LastName = this.LastName.Text;
                }

                data.SaveChanges();
                Notifier.Success("Account successfully updated");
                this.Response.Redirect("~/Account/Manage.aspx", true);
            }
            catch (Exception err)
            {
                // TODO: this is wrong
                if (err.Message != "Thread was being aborted.")
                {
                    Notifier.Error(err.Message);
                }
            }
        }
    }
}