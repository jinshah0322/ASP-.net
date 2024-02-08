<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeProject.aspx.cs" Inherits="EmployeeManagement.EmployeeProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Employee Project Form</h1>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAssignmentDate" runat="server" ControlToValidate="AssignmentDate"
                                ErrorMessage="Please Enter Assignment Date" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>HoursWorked</td>
                        <td>
                            <asp:TextBox TextMode="Number" ID="HoursWorked" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNumber" runat="server" ControlToValidate="HoursWorked"
                                ErrorMessage="Please Enter Hours Worked" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidatorHoursWorked" runat="server" ControlToValidate="HoursWorked"
                                ErrorMessage="Enter value Between 0 to 500" ForeColor="Red" MaximumValue="500" MinimumValue="0"
                                SetFocusOnError="True" Type=" Integer"></asp:RangeValidator>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorStatus" runat="server" ControlToValidate="Status"
                                ErrorMessage="Please Enter Assignment Date" ForeColor="Red"></asp:RequiredFieldValidator>
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
                OnRowDataBound="OnRowDataBound" DataKeyNames="EPID" OnRowEditing="OnRowEditing"
                OnRowCancelingEdit="OnRowCancelingEdit" AllowPaging="True" OnPageIndexChanging="OnPaging"
                OnRowDeleting="OnRowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="EmployeeID" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="txtEmployeeID" runat="server" Width="140"></asp:DropDownList>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProjectID" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblProjectID" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="txtProjectID" runat="server" Width="140"></asp:DropDownList>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AssignmentDate" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblAssignmentDate" runat="server" Text='<%# Eval("AssignmentDate") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox TextMode="Date" ID="txtAssignmentDate" runat="server" Text='<%# Eval("AssignmentDate") %>' Width="140"></asp:TextBox>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HoursWorked" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="HoursWorked" runat="server" Text='<%# Eval("HoursWorked") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox TextMode="Number" ID="txtHoursWorked" runat="server" Text='<%# Eval("HoursWorked") %>' Width="140"></asp:TextBox>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
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
        </div>
    </form>
</body>
</html>
