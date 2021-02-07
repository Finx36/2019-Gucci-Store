<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sotrudniki.aspx.cs" Inherits="WebApp.Sotrudnik_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .bt_Style {}
        .gvStyle {}
        .tb_Style {}
    </style>
</head>
<body>
    <form id="SotrudnikPage" runat="server">
        <asp:SqlDataSource ID="sdsSotrudnik" runat ="server"></asp:SqlDataSource>
        <center>
            <asp:Label ID ="lblTitle" runat ="server" Text= "Список сотрудников" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
        <div style ="overflow : unset">
            <div style ="float : left">
            <asp:Label ID="lblSurname" runat ="server"
                 Text ="Фамилия сотрудника" CssClass ="font_style"></asp:Label>
            <br>
            <asp:TextBox ID="tbSurname" runat ="server" CssClass ="tb_Style" Text ="Введите фамилию" Width="225px"></asp:TextBox>
            <br>
            <asp:Label ID="lblName" runat ="server"
                CssClass ="font_style" Text ="Имя сотрудника"></asp:Label>
            <br>
            <asp:TextBox ID="tbName" runat ="server"  CssClass ="tb_Style" Text ="Введите имя" Width="223px"></asp:TextBox>
            <br>
            <asp:Label ID="lblMiddleName" runat ="server"
                CssClass ="font_style" Text ="Отчество сотрудника"></asp:Label>
            <br>
            <asp:TextBox ID="tbMiddleName" runat ="server"  CssClass ="tb_Style" Text ="Введите отчество" Width="225px"></asp:TextBox>
            <br>
            <asp:Label ID="lblDateOfBirth" runat ="server"
            CssClass ="font_style" Text ="Дата рождения сотрудника"></asp:Label>
            <br>
            <asp:TextBox ID="tbDateOfBirth" runat ="server"  CssClass ="tb_Style" Text ="Введите дату рождения" Width="226px"></asp:TextBox>
            <br>
                 <asp:Label ID="lblPassportNubmer" runat ="server"
            CssClass ="font_style" Text ="Номер паспорта"></asp:Label>
            <br>
            <asp:TextBox ID="tbPSNumber" runat ="server"  CssClass ="tb_Style" Text ="Введите номер паспорта" Width="226px"></asp:TextBox>
            <br>
                 <asp:Label ID="lblPassportSeries" runat ="server"
            CssClass ="font_style" Text ="Серия паспорта"></asp:Label>
            <br>
            <asp:TextBox ID="tbPSSeries" runat ="server"  CssClass ="tb_Style" Text ="Введите серию паспорта" Width="226px"></asp:TextBox>
            <br>
           
            <asp:Label ID="lblUserName" runat ="server"
               CssClass ="font_style" Text ="Логин сотрудника"></asp:Label>
            <br>
            <asp:TextBox ID="tbUserName" runat ="server"  CssClass ="tb_Style" Width="223px"></asp:TextBox>
            <br>
            <asp:Label ID="lblPassword" runat ="server"
                CssClass ="font_style" Text ="Пароль сотрудника"></asp:Label>
            <br>
            <asp:TextBox ID="tbPassword" runat ="server" CssClass ="tb_Style" TextMode ="Password" Width="221px"></asp:TextBox>
            <br>
            <asp:Label ID="lblConfirmPassword" runat ="server"
                CssClass ="font_style" Text ="Подтверждение пароля"></asp:Label>
            <br>
            <asp:TextBox ID="tbConfirmPassword" runat ="server"  CssClass ="tb_Style" TextMode ="Password" Width="219px"></asp:TextBox>
            <br>
            
               <asp:Label ID="lblPosition" runat ="server"
               CssClass ="font_style" Text ="Должность сотрудника"></asp:Label>
            <br>
                <asp:DropDownList ID="ddlPosition" runat="server">
                </asp:DropDownList>
                <br>
            <br>
                <center>
                <asp:Button ID = "btInsert" runat ="server" CssClass ="bt_Style" 
                    Text ="Добавить нового сотрудника" OnClick="btInsert_Click" /><br> 
                <asp:Button ID = "btUpdate" runat ="server" CssClass ="bt_Style" 
                    Text ="Изменить данные о сотруднике" OnClick="btUpdate_Click" /><br>
                 <asp:Button ID = "btDelete" runat ="server" CssClass ="bt_Style" 
                    Text ="Удалить сотрудника" OnClick="btDelete_Click" /><br>
                    <br>
                    </center>
                </div>
            <br>
            
             <center>
                    <asp:Label ID ="lblSearch" runat ="server" 
                        Text ="Введите значение для поиска" CssClass="font_style"></asp:Label>
                 <br>
                    <asp:TextBox ID="tbSearch" runat ="server" 
                        CssClass ="tb_Style"></asp:TextBox>
                    <br>
                    <asp:Button ID ="btSearch" runat ="server" 
                        CssClass ="bt_Style" Text ="Поиск" OnClick="btSearch_Click" />
                    <asp:Button ID ="btFilter" runat ="server" 
                        CssClass ="bt_Style" Text ="Фильтр" OnClick="btFilter_Click"  />
                    <asp:Button ID ="btCancel" runat ="server" 
                        CssClass ="bt_Style" Text ="Отмена" OnClick="btCancel_Click" />
                <asp:GridView ID ="gvWorkInformation" runat ="server" 
                    AllowSorting ="true"
                    CssClass ="gvStyle" OnRowDataBound="gvWorker_RowDataBound" 
                    OnSelectedIndexChanged="gvWorker_SelectedIndexChanged" OnSorting ="gvWorker_Sorting"
                    CurrentSortField ="" CurrentSortDirection ="ASC" >
                    <Columns>
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                </asp:GridView>
                 
                     <div style ="float : left">
                     <asp:Label ID ="lblPreviousPage" runat ="server" 
                        Text ="Список транспортных дней" CssClass="font_style"></asp:Label>
                     <br>
                      <asp:Button ID ="btPreviousPage" runat ="server" 
                        CssClass ="bt_Style" Text ="Предыдущая страница" OnClick="btPreviousPage_Click" />
                     </div>

                    <div style ="float : right">
                     <asp:Label ID ="lblNextPage" runat ="server" 
                        Text ="График сотрудника" CssClass="font_style"></asp:Label>
                     <br>
                      <asp:Button ID ="btNextPage" runat ="server" 
                        CssClass ="bt_Style" Text ="Следующая страница" OnClick="btNextPage_Click" />
                    </div>
              
                 </center>
                 
    </form>
</body>
</html>
