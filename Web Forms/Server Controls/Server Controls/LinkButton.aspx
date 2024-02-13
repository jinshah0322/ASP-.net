<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkButton.aspx.cs" Inherits="linkbutton.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Click Here" OnClick="HandelReq"></asp:LinkButton>
        </div>
    </form>
    <h2>
        <asp:Label ID="Label1" runat="server" ></asp:Label>
    </h2>
</body>
</html>
