<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="radiobutton.aspx.cs" Inherits="radioButton.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButton ID="RadioButton1" Text="Male" GroupName="Gender" runat="server"/>
            <asp:RadioButton ID="RadioButton2" Text="Female" GroupName="Gender" runat="server"/>
        </div>
        <p>
            <asp:Button ID="Button1" Text="Submit" OnClick="Button1_Click" runat="server"/>
        </p> 
    </form>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</body>
</html>
