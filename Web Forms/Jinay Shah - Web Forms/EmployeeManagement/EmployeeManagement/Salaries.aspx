<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salaries.aspx.cs" Inherits="EmployeeManagement.Salaries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Salary Form</h1>
        <div>
            <table>
                <tr>
                    <td>Amount</td>
                    <td>
                        <asp:TextBox ID="Amount" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidateAmount" runat="server" ControlToValidate="Amount"
                            ErrorMessage="Please Enter Amount" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>EmployeeID</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEmployeeID" AutoPostBack="true" CausesValidation="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ValidateEID" runat="server" ControlToValidate="ddlEmployeeID"
                            ErrorMessage="Please Enter Employee ID" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>SalaryType</td>
                    <td>
                        <asp:DropDownList ID="ddlSalaryType" runat="server">
                            <asp:ListItem Value="">Please Select</asp:ListItem>
                            <asp:ListItem>Net Banking</asp:ListItem>
                            <asp:ListItem>Cash</asp:ListItem>
                            <asp:ListItem>UPI</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSalaryType"
                            ErrorMessage="Please Select salary type" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Bonus</td>
                    <td>
                        <asp:TextBox ID="Bonus" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Bonus"
                            ErrorMessage="Please Enter Bonus" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Bonus"
                            ErrorMessage="Enter value between 0-500000" ForeColor="Red" MaximumValue="500000" MinimumValue="0"
                            SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>FinalSalary</td>
                    <td>
                        <asp:TextBox ID="FinalSalary" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FinalSalary"
                            ErrorMessage="Please Enter Bonus" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="FinalSalary"
                            ControlToValidate="Amount" Display="Dynamic" ErrorMessage="Final salary cant be less than amount" ForeColor="Red"
                            Operator="LessThanEqual" Type="Integer"></asp:CompareValidator>
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
            OnRowDataBound="OnRowDataBound" DataKeyNames="SalaryID" OnRowEditing="OnRowEditing"
            OnRowCancelingEdit="OnRowCancelingEdit" AllowPaging="True" OnPageIndexChanging="OnPaging"
            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="EmployeeID" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlEmployeeIDEdit"></asp:DropDownList>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("Amount") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SalaryType" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblSalaryType" runat="server" Text='<%# Eval("SalaryType") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="txtddlSalaryType" runat="server">
                            <asp:ListItem Value="">Please Select</asp:ListItem>
                            <asp:ListItem>Net Banking</asp:ListItem>
                            <asp:ListItem>Cash</asp:ListItem>
                            <asp:ListItem>UPI</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bonus" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblBonus" runat="server" Text='<%# Eval("Bonus") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBonus" runat="server" Text='<%# Eval("Bonus") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FinalSalary" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblFinalSalary" runat="server" Text='<%# Eval("FinalSalary") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFinalSalary" runat="server" Text='<%# Eval("FinalSalary") %>' Width="140"></asp:TextBox>
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
