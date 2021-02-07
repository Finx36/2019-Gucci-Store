<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authorization.aspx.cs" Inherits="WebApp.Authorization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="AuthorizationPage" runat="server">
       <center>
        <div>
            <asp:Label ID ="lblTitle" runat ="server" CssClass ="font_style"
                Text ="Авторизация"></asp:Label> 
            <br>
            <br>
            <asp:Label ID ="lblMessage" runat ="server" Text =""
                CssClass ="font_style"></asp:Label>
            <br>
            <br>
            <asp:Label ID ="lblLogin" runat ="server" Text ="Логин пользователя"
                CssClass ="font_style"></asp:Label>
            <br>    
            <asp:TextBox id="tbLogin" runat ="server" TextMode ="Password"
                CssClass ="tb_Style" OnTextChanged="tbLogin_TextChanged"></asp:TextBox>
            <br>
            <asp:Label ID ="lblPassword" runat ="server" Text ="Пароль пользователя"
                CssClass ="font_style"></asp:Label>
            <br>
            <asp:TextBox id="tbPassword" runat ="server" TextMode ="Password"
                CssClass ="tb_Style"></asp:TextBox>
            <br>
            <br>
            <asp:Button ID ="btEnter" runat ="server" Text ="Войти" 
                CssClass ="bt_Style" OnClick="btEnter_Click" />
        </div>
        </center>
    </form>
</body>
</html>
