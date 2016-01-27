<%@ Page
    Title="Add Employee"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Create.aspx.cs"
    Inherits="EmployeeFinder.WebForms.Employees.AddEmployee" %>

<%@ Register Src="~/Controls/ImageFromUrl/ImageFromUrlSave.ascx" TagPrefix="uc1" TagName="ImageFromUrlSave" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FirstName" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The name field is required." />
                <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="FirstName"
                    ValidationExpression="^[\s\S]{5,30}$"
                    CssClass="text-danger" ErrorMessage="The name length must be between 3 and 30 symbols." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Second Name:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LastName" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-danger" ErrorMessage="The name field is required." />
                <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="LastName"
                    ValidationExpression="^[\s\S]{5,30}$"
                    CssClass="text-danger" ErrorMessage="The name length must be between 3 and 30 symbols." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FileUploadImage" CssClass="col-md-2 control-label">Employee photo:</asp:Label>
            <div class="col-md-4">
                <asp:FileUpload runat="server" ID="FileUploadImage" CssClass="form-control" />
                <asp:RegularExpressionValidator ID="RevImg" runat="server" ControlToValidate="FileUploadImage"
                    ErrorMessage="Invalid File!(only  .gif, .jpg, .jpeg Files are supported)"
                    ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.jpeg|JPEG)$" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ControlImageUrl" CssClass="col-md-2 control-label">Or image url:</asp:Label>
            <div class="col-md-4">
                <uc1:ImageFromUrlSave runat="server" ID="ControlImageUrl" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Comment" CssClass="col-md-2 control-label">Comment on this employee:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Comment" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Comment"
                    CssClass="text-danger" ErrorMessage="The content field is required." />
                <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="Comment"
                    ValidationExpression="^[\s\S]{5,200}$"
                    CssClass="text-danger" ErrorMessage="The title length must be between 5 and 200 symbols." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Possition" CssClass="col-md-2 control-label">Possition:</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="Possition" CssClass="form-control"> </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Possition"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The possition field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Rating" CssClass="col-md-2 control-label">Rate:</asp:Label>
            <asp:RadioButtonList ID="Rating" runat="server" >
                
            </asp:RadioButtonList>

        </div>
        

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="OnClick" Text="Create" CssClass="btn btn-default" />
                <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx" Text="Cancel" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>