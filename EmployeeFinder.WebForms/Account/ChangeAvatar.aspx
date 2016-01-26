<%@ Page Title="Change Avatar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ChangeAvatar.aspx.cs" Inherits="EmployeeFinder.WebForms.Account.ChangeAvatar" %>

<%@ Register Src="~/Controls/ImageFromUrl/ImageFromUrlSave.ascx" TagPrefix="uc1" TagName="ImageFromUrlSave" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-4 col-md-offset-4">
            <asp:Image runat="server" ID="Avatar" CssClass="thumbnail col-md-10" />
        </div>
        <div class="row">
            <div class="col-md-offset-4 col-md-4">
                <div class="form-group-sm">
                    <div class="row">
                        <asp:FileUpload runat="server" ID="FileUploadAvatar" CssClass="form-control" />
                        <asp:RegularExpressionValidator ID="RevImg" runat="server" ControlToValidate="FileUploadAvatar"
                            ErrorMessage="Invalid File!(only  .gif, .jpg, .jpeg Files are supported)"
                            ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.jpeg|JPEG)$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="row">
                        <asp:Button ID="ButtonUpload" runat="server" Text="Upload" CssClass="btn btn-default btn-block" OnClick="ButtonUpload_OnClick" />
                    </div>
                    
                    <div class="row">
                        <p>Or give URL..</p>                      
                        <uc1:ImageFromUrlSave runat="server" id="ControlImageFromUrl"/>
                        <asp:Button runat="server" ID="ButtonUploadControl" CssClass="btn btn-default btn-block" Text="Select" OnClick="ButtonUploadControl_OnClick" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

