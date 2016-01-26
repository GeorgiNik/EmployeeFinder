<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageFromUrlSave.ascx.cs" Inherits="EmployeeFinder.WebForms.Controls.ImageFromUrl.ImageFromUrlSave" %>


<asp:TextBox runat="server" ID="ImageUploadUrl" CssClass="form-control"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidatorUrlUpload" runat="server" ControlToValidate="ImageUploadUrl"
    ErrorMessage="Invalid url format"
    ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?" ForeColor="Red"></asp:RegularExpressionValidator>