<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="textbox.aspx.cs" Inherits="textbox.WebForm1" %>

<!DOCTYPE html>  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
        <div>  
            <asp:Label ID="labelId" runat="server">User Name</asp:Label>  
            <asp:TextBox ID="UserName" runat="server" ToolTip="Enter User Name"></asp:TextBox>  
        </div>  
        <p>  
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />  
        </p>  
        <br />                   
    </form>  
    <asp:Label ID="userInput" runat="server"></asp:Label>
</body>  
</html> 