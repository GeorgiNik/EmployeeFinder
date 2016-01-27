<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EmployeeFinder.WebForms.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: this.Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: this.SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Change your account settings</h4>
                <hr />
                <div class="col-md-3">
                    <asp:Image runat="server" ID="Avatar" CssClass="thumbnail col-md-12" />
                    <asp:HyperLink NavigateUrl="/Account/ChangeAvatar" Text="[Change Avatar]" ID="ChangeAvatar" runat="server" />
                </div>

                <div class="form-group col-md-9">
                    <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" placeholder='First Name' />
                        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="FirstName"
                            ValidationExpression=".{3}.*"
                            CssClass="text-danger" ErrorMessage="Minimum first name length is 3." />
                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="FirstName"
                            CssClass="text-danger" ErrorMessage="The first name field is required." />
                    </div>
                </div>
                <div class="form-group col-md-9">
                    <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last Name</asp:Label>

                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="LastName" CssClass="form-control" placeholder='Last Name' />
                        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="LastName"
                            ValidationExpression=".{3}.*"
                            CssClass="text-danger" ErrorMessage="Minimum first name length is 3." />
                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="LastName"
                            CssClass="text-danger" ErrorMessage="The first name field is required." />
                    </div>
                    
                </div>
               <dl class=" col-md-9 ">
                    <dt class="col-md-3" style="text-align: center">Password:</dt>
                    <dd class="col-md-4">
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                </dl>

                <div class="form-group col-md-9">
                    <div class="col-md-offset-6">
                        <asp:Button runat="server" OnClick="UpdateAccount_Click" Text="Update" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
    </div>
    </div>

</asp:Content>
