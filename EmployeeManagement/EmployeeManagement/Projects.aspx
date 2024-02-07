<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="EmployeeManagement.Projects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Projects Form</h1>
        <div>
            <table>
                <tr>
                    <td>ProjectID</td>
                    <td>
                        <asp:DropDownList ID="ProjectName" runat="server" Width="400"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ValidateProjectName" runat="server" ControlToValidate="ProjectName"
                            ErrorMessage="Please Enter Project Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>ProjectManager</td>
                    <td>
                        <asp:TextBox ID="ProjectManager" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidateProjectManager" runat="server" ControlToValidate="ProjectManager"
                            ErrorMessage="Please Enter Project Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>StartDate</td>
                    <td>
                        <asp:TextBox TextMode="Date" ID="StartDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>EndDate</td>
                    <td>
                        <asp:TextBox TextMode="Date" ID="EndDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Budget</td>
                    <td>
                        <asp:TextBox ID="Budget" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>IsActive</td>
                    <td>
                        <asp:RadioButtonList ID="isActive" runat="server">
                            <asp:ListItem Text="True" Value="True" ></asp:ListItem>
                            <asp:ListItem Text="False" Value="False" ></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click"/>
                        <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="BtnHome_Click" CausesValidation="false"/>
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No records has been added."
            OnRowDataBound="OnRowDataBound" DataKeyNames="ProjectID" OnRowEditing="OnRowEditing"
            OnRowCancelingEdit="OnRowCancelingEdit" PageSize="10" AllowPaging="true" OnPageIndexChanging="OnPaging" OnRowUpdating="OnRowUpdating"
            OnRowDeleting="OnRowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="ProjectID" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="txtProjectName" runat="server" Width="140"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProjectManager" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectManager" runat="server" Text='<%# Eval("ProjectManager") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProjectManager" runat="server" Text='<%# Eval("ProjectManager") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StartDate" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox TextMode="Date" ID="txtStartDate" runat="server" Text='<%# Eval("StartDate") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EndDate" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox TextMode="Date" ID="txtEndDate" runat="server" Text='<%# Eval("EndDate") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Budget" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblBudget" runat="server" Text='<%# Eval("Budget") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBudget" runat="server" Text='<%# Eval("Budget") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="isActive" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblisActive" runat="server" Text='<%# Eval("isActive") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="txtIsActive" runat="server">
                            <asp:ListItem Text="True" Value="True" ></asp:ListItem>
                            <asp:ListItem Text="False" Value="False" ></asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" CausesValidation="false" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
