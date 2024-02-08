<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="EmployeeManagement.Department" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Department Form</h1>
        <div>
            <table>
                <tr>
                    <td>Department Name</td>
                    <td>
                        <asp:TextBox ID="DepartmentName" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidateDName" runat="server" ControlToValidate="DepartmentName"
                            ErrorMessage="Please Enter Department Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Department Head</td>
                    <td>
                        <asp:TextBox ID="DepartmentHead" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidateDHead" runat="server" ControlToValidate="DepartmentHead"
                            ErrorMessage="Please Enter Department Head" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Budget</td>
                    <td>
                        <asp:TextBox ID="Budget" runat="server" Width="400"></asp:TextBox>
                        <asp:RangeValidator ID="validateBudget" runat="server" ControlToValidate="Budget"
                            ErrorMessage="Enter Budget between 100-100000000" ForeColor="Red" MaximumValue="100000000" MinimumValue="100"
                            SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                        <asp:RequiredFieldValidator ID="ValidateBudgetselect" runat="server" ControlToValidate="Budget"
                            ErrorMessage="Please Enter Budget" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Creation Date</td>
                    <td>
                        <asp:Calendar ID="CreationDate" runat="server"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>Department Status</td>
                    <td>
                        <asp:RadioButton ID="DepartmentStatus1" Text="Active" runat="server" GroupName="isActive" />
                        <asp:RadioButton ID="DepartmentStatus2" Text="InActive" runat="server" GroupName="isActive" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" />
                        <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="BtnHome_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No records has been added."
            OnRowDataBound="OnRowDataBound" DataKeyNames="DepartmentID" OnRowEditing="OnRowEditing"
            OnRowCancelingEdit="OnRowCancelingEdit" PageSize="10" AllowPaging="true" OnPageIndexChanging="OnPaging" OnRowUpdating="OnRowUpdating"
            OnRowDeleting="OnRowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Department Name" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentName" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDepartmentName" runat="server" Width="140" Text='<%# Eval("DepartmentName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Head" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentHead" runat="server" Text='<%# Eval("DepartmentHead") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDepartmentHead" runat="server" Text='<%# Eval("DepartmentHead") %>' Width="140"></asp:TextBox>
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
                <asp:TemplateField HeaderText="Creation Date" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblCreationDate" runat="server" Text='<%# Eval("CreationDate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox TextMode="Date" ID="txtCreationDate" runat="server" Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Status" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDStatus" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="txtDStatus" runat="server" Checked='<%# Convert.ToBoolean(Eval("IsActive")) %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" CausesValidation="false" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
