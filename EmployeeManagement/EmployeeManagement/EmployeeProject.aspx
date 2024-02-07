﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeProject.aspx.cs" Inherits="EmployeeManagement.EmployeeProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Projects Form</h1>
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
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" />
                            <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="BtnHome_Click" CausesValidation="false"/>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No records has been added."
                OnRowDataBound="OnRowDataBound" DataKeyNames="EPID" OnRowEditing="OnRowEditing"
                OnRowCancelingEdit="OnRowCancelingEdit" PageSize="10" AllowPaging="true" OnPageIndexChanging="OnPaging"
                OnRowDeleting="OnRowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="EmployeeID" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="txtEmployeeID" runat="server" Width="140"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProjectID" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblProjectID" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="txtProjectID" runat="server" Width="140"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AssignmentDate" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblAssignmentDate" runat="server" Text='<%# Eval("AssignmentDate") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox TextMode="Date" ID="txtAssignmentDate" runat="server" Text='<%# Eval("AssignmentDate") %>' Width="140"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HoursWorked" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="HoursWorked" runat="server" Text='<%# Eval("HoursWorked") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox TextMode="Number" ID="txtHoursWorked" runat="server" Text='<%# Eval("HoursWorked") %>' Width="140"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:RadioButtonList ID="txtStatus" runat="server">
                                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                <asp:ListItem Text="Working" Value="Working"></asp:ListItem>
                                <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                            </asp:RadioButtonList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                        ItemStyle-Width="150" CausesValidation="false" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
