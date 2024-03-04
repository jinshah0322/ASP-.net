<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyperlink.aspx.cs" Inherits="hyperlink.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="link1" runat="server" NavigateUrl="https://github.com/jinshah0322" Text="Click here" ToolTip="click here"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
