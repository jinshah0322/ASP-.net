<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadFile.aspx.cs" Inherits="Download_File.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" Text="Download" OnClick="HandleDownload" runat="server"/>
        </div>
    </form>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</body>
</html>
