<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cookie1.aspx.cs" Inherits="Cookie1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" Text="Select Brand Preferences" runat="server"></asp:Label>
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Apple"/>
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Samsung"/>
            <br />
            <asp:CheckBox ID="CheckBox3" runat="server" Text="One Plus"/>
            <br />
            <asp:CheckBox ID="CheckBox4" runat="server" Text="Nothing"/>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="cookie" Text="Submit"/>
        </div>
    </form>
    <asp:Label ID="Label2" runat="server"></asp:Label>
</body>
</html>
