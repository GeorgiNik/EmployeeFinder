<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeFinder.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>EmployeeFinder</h1>
        <p class="lead">EmployeeFinder is web application where managers can find,check and rate employees</p>
        <div class="row">
        <div class="col-md-6">
            <h2><asp:Literal runat="server" ID="TotalUsers"></asp:Literal></h2>
        </div>
        <div class="col-md-6">
            <h2><asp:Literal runat="server" ID="TotalEmployees"></asp:Literal></h2>
        </div>
    </div>
    </div>

    
    <asp:ListView ID="ListViewEmployees" runat="server"
            >
            <LayoutTemplate>
                <h2>Employees:</h2>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <div class="product-description">
                    <asp:HyperLink ID="GoTo" NavigateUrl='<%# String.Concat("~/Employees/Details.aspx?id=",this.Eval("Id")) %>' runat="server"><h3><%#: this.Eval("FirstName") %>	&nbsp; <%#: Eval("LastName") %></asp:HyperLink><br/>
                   
                    
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
