<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmplyeeProject.aspx.cs" Inherits="EmployeeManagement.EditEmplyeeProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Hello world</h1>
        <div>
            <table>
                <tr>
                    <td>EmployeeID</td>
                    <td>
                        <asp:DropDownList ID="EmployeeID" runat="server" Width="400" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ValidateEmployeeID" runat="server" ControlToValidate="EmployeeID"
                            ErrorMessage="Please Enter Project Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>ProjectID</td>
                    <td>
                        <asp:DropDownList ID="ProjectID" runat="server" Width="400" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ValidateProjectID" runat="server" ControlToValidate="ProjectID"
                            ErrorMessage="Please Enter Project Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>AssignmentDate</td>
                    <td>
                        <asp:TextBox TextMode="Date" ID="AssignmentDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>HoursWorked</td>
                    <td>
                        <asp:TextBox TextMode="Number" ID="HoursWorked" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Status</td>
                    <td>
                        <asp:RadioButtonList ID="Status" runat="server">
                            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                            <asp:ListItem Text="Working" Value="Working"></asp:ListItem>
                            <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
                        <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="BtnHome_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>