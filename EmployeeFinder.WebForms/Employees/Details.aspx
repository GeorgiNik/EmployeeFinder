<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    Title="Employee details"
    CodeBehind="Details.aspx.cs"
    Inherits="EmployeeFinder.WebForms.Employees.Details" %>

<asp:Content ID="DetailsContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="form-group col-md-12">
        <asp:Image ID="Image1" runat="server" CssClass="img-thumbnail col-md-3" />
        <div class="form-horizontal col-md-9">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FirstName" TextMode="SingleLine" ReadOnly="True" CssClass="form-control" />

                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Second Name:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="LastName" TextMode="SingleLine" ReadOnly="True" CssClass="form-control" />

                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="EmployeePosition" CssClass="col-md-2 control-label">Possition:</asp:Label>
                <div class="col-md-10">

                    <asp:TextBox runat="server" ID="EmployeePosition" TextMode="SingleLine" ReadOnly="True" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="EmployeeRating" CssClass="col-md-2 control-label">Rating:</asp:Label>
                <div class="col-md-10">

                    <asp:TextBox runat="server" ID="EmployeeRating" TextMode="SingleLine" ReadOnly="True" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group ">
                <asp:Label runat="server" AssociatedControlID="Rating" CssClass="col-md-2 control-label">Rate:</asp:Label>
                <asp:RadioButtonList ID="Rating" runat="server">
                </asp:RadioButtonList>
                <asp:Button ID="btnRate" CssClass="btn btn-primary col-md-4" runat="server" Text="Rate" OnClick="btnRate_OnClick" />
            </div>
        </div>

    </div>
    <asp:ListView ID="lvComments" runat="server">
        <ItemTemplate>
            <div runat="server" style="display: inline-block;" class="form-group col-md-9">
                <div class="form-horizontal">
                    <asp:Button CssClass="btn btn-primary " runat="server" Text="Like" OnCommand="ButtonOnCommand" CommandArgument='<%#:
                this.Eval("Id") %>'
                        CommandName="like" />
                    <asp:Label runat="server"><%#:
                this.Eval("Likes") %></asp:Label>
                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Dislike" OnCommand="ButtonOnCommand" CommandArgument='<%#:
                this.Eval("Id") %>'
                        CommandName="dislike" />
                    <asp:Label runat="server"><%#:
                this.Eval("Dislikes") %></asp:Label>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Comment" CssClass=" control-label">Comment on this employee:</asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="Comment" TextMode="MultiLine" Text='<%#:Eval("Content") %>' ReadOnly="True" CssClass="form-control" />

                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
   

</asp:Content>
