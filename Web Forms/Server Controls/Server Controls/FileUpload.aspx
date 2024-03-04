<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileupload.aspx.cs" Inherits="fileupload.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Upload file:</h2>
            <asp:FileUpload ID="FileUpload1" runat="server"/>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="HandleRequest" Text="Submit"/>
        </div>
        <h2>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label
        </h2>
    </form>
</body>
</html>
