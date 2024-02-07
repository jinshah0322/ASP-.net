<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EmployeeManagement.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Employee Form</h1>
        <div>
            <table>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidateFName" runat="server" ControlToValidate="FirstName"
                            ErrorMessage="Please Enter First Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidateLName" runat="server" ControlToValidate="LastName"
                            ErrorMessage="Please Enter Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Date Of Birth</td>
                    <td>
                        <asp:TextBox TextMode="Date" ID="DOB" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td>
                        <asp:RadioButtonList ID="gender" runat="server">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Salary</td>
                    <td>
                        <asp:TextBox ID="salary" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Joining Date</td>
                    <td>
                        <asp:TextBox TextMode="Date" ID="JoiningDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Department ID</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlDepartmentName" AutoPostBack="true" CausesValidation="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Interested Technology</td>
                    <td>
                        <asp:CheckBox ID="asp" runat="server" Text="ASP.NET" />
                        <asp:CheckBox ID="PHP" runat="server" Text="PHP" />
                        <asp:CheckBox ID="SpringBoot" runat="server" Text="SpringBoot" />
                        <asp:CheckBox ID="Nodejs" runat="server" Text="Nodejs" />
                    </td>
                </tr>
                <tr>
                    <td>State</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlState" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>City</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCity"></asp:DropDownList>
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
            OnRowDataBound="OnRowDataBound" DataKeyNames="EmployeeID" OnRowEditing="OnRowEditing"
            OnRowCancelingEdit="OnRowCancelingEdit" PageSize="10" AllowPaging="true" OnPageIndexChanging="OnPaging" OnRowUpdating="OnRowUpdating"
            OnRowDeleting="OnRowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="FirstName" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Eval("FirstName") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" runat="server" Text='<%# Eval("LastName") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateOfBirth" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDateOfBirth" runat="server" Text='<%# Eval("DateOfBirth") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox TextMode="Date" ID="txtDateOfBirth" runat="server" Text='<%# Eval("DateOfBirth") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="txtgender" runat="server">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Salary" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblSalary" runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSalary" runat="server" Text='<%# Eval("Salary") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JoiningDate" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblJoiningDate" runat="server" Text='<%# Eval("JoiningDate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox TextMode="Date" ID="txtJoiningDate" runat="server" Text='<%# Eval("JoiningDate") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DepartmentID" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentID" runat="server" Text='<%# Eval("DepartmentID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="txtDdlDepartmentEdit" runat="server" Width="140">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="InterestedTechnologies" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblInterestedTechnologies" runat="server" Text='<%# Eval("InterestedTechnologies") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" CausesValidation="false" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
