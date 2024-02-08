<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeManagement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
            <section class="col-md-2" aria-labelledby="hostingTitle">
                <asp:Button ID="Departments" runat="server" Text="Departments" CssClass="btn btn-primary" OnClick="btnDepartments"/>
            </section>
            <section class="col-md-2" aria-labelledby="hostingTitle">
                <asp:Button ID="Employees" runat="server" Text="Employees" CssClass="btn btn-primary" OnClick="btnEmployees"/>
            </section>
            <section class="col-md-2" aria-labelledby="hostingTitle">
                <asp:Button ID="Salaries" runat="server" Text="Salaries" CssClass="btn btn-primary" OnClick="btnSalaries"/>
            </section>
            <section class="col-md-2" aria-labelledby="librariesTitle">
                <asp:Button ID="Projects" runat="server" Text="Projects" CssClass="btn btn-primary" OnClick="btnProjects"/>
            </section>
            <section class="col-md-2" aria-labelledby="gettingStartedTitle">
                <asp:Button ID="EmployeeProject" Text="EmployeeProject" runat="server" CssClass="btn btn-primary" OnClick="btnEmployeeProject"/>
            </section>
        </div>

    </main>

</asp:Content>
