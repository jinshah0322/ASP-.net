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
                    <td>ProjectName</td>
                    <td>
                        <asp:TextBox ID="ProjectName" runat="server" Width="400"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="ValidateStartDate" runat="server" ControlToValidate="StartDate"
                            ErrorMessage="Please Enter Start Date" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>EndDate</td>
                    <td>
                        <asp:TextBox TextMode="Date" ID="EndDate" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidateEndDate" runat="server" ControlToValidate="EndDate"
                            ErrorMessage="Please Enter End Date" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorDate" runat="server" ControlToCompare="StartDate"
                            ControlToValidate="EndDate" Display="Dynamic" ErrorMessage="End date must be greater than or equal to Start date" ForeColor="Red"
                            Operator="GreaterThanEqual" Type="Date" SetFocusOnError="true"></asp:CompareValidator>

                    </td>
                </tr>
                <tr>
                    <td>Budget</td>
                    <td>
                        <asp:TextBox ID="Budget" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="validateBudget" runat="server" ControlToValidate="Budget"
                            ErrorMessage="Enter Budget between 100-100000000" ForeColor="Red" MaximumValue="100000000" MinimumValue="100"
                            SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                        <asp:RequiredFieldValidator ID="ValidateBudgetselect" runat="server" ControlToValidate="Budget"
                            ErrorMessage="Please Enter Budget" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>IsActive</td>
                    <td>
                        <asp:RadioButtonList ID="isActive" runat="server">
                            <asp:ListItem Text="True" Value="True"></asp:ListItem>
                            <asp:ListItem Text="False" Value="False"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="ValidateIsActive" runat="server" ControlToValidate="isActive"
                            ErrorMessage="Please Enter IsActive Status" ForeColor="Red"></asp:RequiredFieldValidator>
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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No records has been added."
            OnRowDataBound="OnRowDataBound" DataKeyNames="ProjectID" OnRowEditing="OnRowEditing"
            OnRowCancelingEdit="OnRowCancelingEdit" AllowPaging="True" OnPageIndexChanging="OnPaging" OnRowUpdating="OnRowUpdating"
            OnRowDeleting="OnRowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="ProjectName" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProjectName" runat="server" Width="140" Text='<%# Eval("ProjectName") %>'></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProjectManager" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectManager" runat="server" Text='<%# Eval("ProjectManager") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProjectManager" runat="server" Text='<%# Eval("ProjectManager") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StartDate" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox TextMode="Date" ID="txtStartDate" runat="server" Text='<%# Eval("StartDate") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EndDate" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox TextMode="Date" ID="txtEndDate" runat="server" Text='<%# Eval("EndDate") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Budget" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblBudget" runat="server" Text='<%# Eval("Budget") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBudget" runat="server" Text='<%# Eval("Budget") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="isActive" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblisActive" runat="server" Text='<%# Eval("isActive") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="txtIsActive" runat="server">
                            <asp:ListItem Text="True" Value="True"></asp:ListItem>
                            <asp:ListItem Text="False" Value="False"></asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" CausesValidation="false" >
<ItemStyle Width="150px"></ItemStyle>
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </form>
</body>
</html>
