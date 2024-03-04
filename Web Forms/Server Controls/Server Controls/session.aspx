<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="session.aspx.cs" Inherits="session.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        auto-style1 {  
            width: 100%;  
        }  
        .auto-style2 {  
            width: 105px;  
        }
        .auto-style3{
            position:absolute;
            left:120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>Provide following details</p>
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Email</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Password</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Login" CssClass="auto-style3" OnClick="login"/><br />
            <br />
            <h3><asp:Label ID="Label1" runat="server"></asp:Label></h3
    </form>
</body>
</html>
