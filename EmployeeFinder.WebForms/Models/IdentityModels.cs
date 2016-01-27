﻿namespace EmployeeFinder.WebForms.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //    public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }

    //    public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
    //    {
    //        return Task.FromResult(GenerateUserIdentity(manager));
    //    }
    //}
}

#region Helpers

namespace EmployeeFinder.WebForms
{
    using System;
    using System.Web;

    using EmployeeFinder.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    public static class IdentityHelper
    {
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";

        public const string CodeKey = "code";

        public const string UserIdKey = "userId";

        public static void SignIn(ApplicationUserManager manager, User user, bool isPersistent)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }

        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri;
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "="
                              + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri;
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url)
                   && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\')))
                       || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!string.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}

#endregion