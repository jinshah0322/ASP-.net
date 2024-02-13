<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDownList.aspx.cs" Inherits="Server_Controls.DropDownList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="">Please Select</asp:ListItem>
                <asp:ListItem Text="Cricket"></asp:ListItem>
                <asp:ListItem Text="Football"></asp:ListItem>
                <asp:ListItem Text="BasketBall"></asp:ListItem>
            </asp:DropDownList>
        </div><br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="dropDown"/><br />  <br />  
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
