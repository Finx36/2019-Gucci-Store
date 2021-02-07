<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="WebApp.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="Projects" runat="server">
        <asp:SqlDataSource ID="sdsProject" runat ="server"></asp:SqlDataSource>
        <center>
            <asp:Label ID ="lblTitle" runat ="server" Text= "Проекты" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
        <div style ="overflow : unset">
            <div style ="float : left">
            <asp:Label ID="lblProjectName" runat ="server"
                 Text ="Название проекта" CssClass ="font_style"></asp:Label>
            <br>
            <asp:TextBox ID="tbProjectName" runat ="server" CssClass ="tb_Style" Text ="Введите название проекта" Width="225px"></asp:TextBox>
            <br>
            <asp:Label ID="lblCost" runat ="server"
                CssClass ="font_style" Text ="Имя сотрудника"></asp:Label>
            <br>
            <asp:TextBox ID="tbCost" runat ="server"  CssClass ="tb_Style" Text ="Введите стоимость" Width="223px"></asp:TextBox>
            <br>
            <asp:Label ID="lblDuration" runat ="server"
                CssClass ="font_style" Text ="Отчество сотрудника"></asp:Label>
            <br>
            <asp:TextBox ID="tbDuration" runat ="server"  CssClass ="tb_Style" Text ="Введите время длительности проекта" Width="225px"></asp:TextBox>
            <br>
                       <asp:Label ID="lblSotrudnik" runat ="server"
                CssClass ="font_style" Text ="ФИО сотрудника"></asp:Label>
                <br>
                <asp:DropDownList ID="ddlSotrudnik" runat="server">
                </asp:DropDownList>
                <br>
                <asp:Label ID="lblSalesResult" runat ="server"
                CssClass ="font_style" Text ="Используемые товары"></asp:Label>
                <br>
                <asp:DropDownList ID="ddlSalesResult" runat="server">
                </asp:DropDownList>
                <br>
            <br>
                <center>
                <asp:Button ID = "btInsert" runat ="server" CssClass ="bt_Style" 
                    Text ="Добавить новый проект" OnClick="btInsert_Click" /><br> 
                <asp:Button ID = "btUpdate" runat ="server" CssClass ="bt_Style" 
                    Text ="Изменить данные о проекте" OnClick="btUpdate_Click" /><br>
                 <asp:Button ID = "btDelete" runat ="server" CssClass ="bt_Style" 
                    Text ="Удалить проект" OnClick="btDelete_Click" /><br>
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
                <asp:GridView ID ="gvProject" runat ="server" 
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
