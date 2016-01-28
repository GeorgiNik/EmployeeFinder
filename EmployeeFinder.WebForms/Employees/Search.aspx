<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="EmployeeFinder.WebForms.Employees.Search" MasterPageFile="~/Site.Master" %>

<asp:Content ID="DetailsContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group col-md-12">
        <div class="form-horizontal">
            <asp:ValidationSummary runat="server" CssClass="text-danger" />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="SearchBox" CssClass="col-md-2 control-label">Search by employee Full Name:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="SearchBox" TextMode="SingleLine" CssClass="form-control" />
                    <asp:Button ID="SearchBtn" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="SearchBtn_OnClick" />
                    <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="SearchBox"
                        ValidationExpression="^[\s\S]{3,60}$"
                        CssClass="text-danger" ErrorMessage="The name length must be between 3 and 60 symbols." />
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <asp:Button ID="btnSortByPosition" CssClass="btn btn-primary col-md-4" runat="server" Text="Sort by Position" OnClick="btnSortByPosition_OnClick" />
        </div>
    </div>
     <asp:ListView ID="ListViewEmployees" runat="server">
         
        <LayoutTemplate>
            <br/>
            <hr/>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>

        <ItemTemplate>
            <div class="product-description">
                <asp:HyperLink ID="GoTo" NavigateUrl='<%# String.Concat("~/Employees/Details.aspx?id=",this.Eval("Id")) %>' runat="server"><h3><%#: this.Eval("FirstName") %>	&nbsp; <%#: Eval("LastName") %></asp:HyperLink><br />
                Position: <%#:Eval("Position") %>
            </div>
        </ItemTemplate>
    </asp:ListView>
        <div class="pager h4">
        <asp:DataPager ID="DataPagerCustomers" runat="server"
            PagedControlID="ListViewEmployees" PageSize="3"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>


</asp:Content>
