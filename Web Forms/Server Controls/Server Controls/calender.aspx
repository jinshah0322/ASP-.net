<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calender.aspx.cs" Inherits="calander.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Calendar ID="Calender1" runat="server" OnSelectionChanged="dataChanged"></asp:Calendar>
        </div>
    </form>
    <h1>
        <asp:Label ID="ShowData" runat="server"></asp:Label>
       </h1>
</body> 
</html>
