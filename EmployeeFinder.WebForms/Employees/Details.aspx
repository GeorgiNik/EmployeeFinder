<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    Title="Employee details"
    CodeBehind="Details.aspx.cs"
    Inherits="EmployeeFinder.WebForms.Employees.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <asp:Image ID="Image1" runat="server" />
        <asp:Label runat="server" ID="lblFirstName"></asp:Label>
        <asp:Label runat="server" ID="lblLastName"></asp:Label>
        <asp:Label runat="server" ID="lblPosition"></asp:Label>
        <asp:Label runat="server" ID="lblRating"></asp:Label>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Rating" CssClass="col-md-2 control-label">Rate:</asp:Label>
        <asp:RadioButtonList ID="Rating" runat="server">
        </asp:RadioButtonList>
        <asp:Button ID="btnRate" runat="server" Text="Rate" OnClick="btnRate_OnClick"/>
    </div>
    <asp:ListView ID="lvComments" runat="server">
        <ItemTemplate>
            <div runat="server" style="display: inline-block;">
                <asp:Button runat="server" Text="Like" OnCommand="ButtonOnCommand" CommandArgument='<%#: Eval("Id")%>' CommandName="like" />
                <asp:Label runat="server"><%#: Eval("Likes")%></asp:Label>
                <asp:Button runat="server" Text="Dislike" OnCommand="ButtonOnCommand" CommandArgument='<%#: Eval("Id")%>' CommandName="dislike" />
                <asp:Label runat="server"><%#: Eval("Dislikes")%></asp:Label>
                <asp:Label runat="server" Text='<%#: Eval("Content") %>'></asp:Label>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
