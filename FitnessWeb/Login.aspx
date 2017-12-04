<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FitnessWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="main.css">
</head>
<body>
    <form class="loginWrapper materialCard" id="form1" runat="server">
        <div ID="loginTopText">Fitness APP - Client Login</div>
        <asp:TextBox ID="loginInput" class="loginInput" AutoCompleteType="Disabled" runat="server" placeholder="Email"></asp:TextBox>
        <asp:TextBox ID="passwordInput" class="loginInput" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
        <asp:Button ID="confirmButton" runat="server" Text="Login" OnClick="Button1_Click" />
    </form>
</body>
</html>
