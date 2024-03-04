<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkbox.aspx.cs" Inherits="checkbox.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Select your favourite Sport:</h2>
        <div>
            <asp:CheckBox ID="CheckBox1" Text="Cricket" runat="server"></asp:CheckBox>
            <asp:CheckBox ID="CheckBox2" Text="Football" runat="server"></asp:CheckBox>
            <asp:CheckBox ID="CheckBox3" Text="BasketBall" runat="server"></asp:CheckBox>
            <asp:Button ID="Button1" Text="Submit" runat="server" OnClick="showData"/>
        </div>
        <h2>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </h2>
    </form>
</body>
</html>
