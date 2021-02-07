<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .tb_Style {}
    </style>
</head>
<body>
    <form id="GraphPage" runat="server">
        <asp:SqlDataSource ID="sdsGraph" runat ="server"></asp:SqlDataSource>
        <center>
        <asp:Label ID ="lblTitle" runat ="server" Text= "Список товаров" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
        <div style ="float : left">
            <asp:Label ID="lblProductName" runat ="server"
             CssClass ="font_style" Text ="Название товара"></asp:Label>
            <br>
            <asp:TextBox ID="tbProductName" runat ="server"  CssClass ="tb_Style" Text ="Введите название товара" Width="259px"></asp:TextBox>
            <br>
             <asp:Label ID="lblPrice" runat ="server"
             CssClass ="font_style" Text ="Цена"></asp:Label>
            <br>
            <asp:TextBox ID="tbPrice" runat ="server"  CssClass ="tb_Style" Text ="Введите цену товара" Width="259px"></asp:TextBox>
            <br>
             <asp:Label ID="lblType" runat ="server"
             CssClass ="font_style" Text ="Тип товара"></asp:Label>
            <br>
            <asp:TextBox ID="tbType" runat ="server"  CssClass ="tb_Style" Text ="Введите тип товара" Width="259px"></asp:TextBox>
            <br>
            <center>
                <br>
                <asp:Button ID = "btInsert" runat ="server" CssClass ="bt_Style" 
                    Text ="Добавить новый товар" OnClick="btInsert_Click" /><br> 
                <asp:Button ID = "btUpdate" runat ="server" CssClass ="bt_Style" 
                    Text ="Изменить данные о товаре" OnClick="btUpdate_Click" /><br>
                 <asp:Button ID = "btDelete" runat ="server" CssClass ="bt_Style" 
                    Text ="Удалить товар" OnClick="btDelete_Click" /><br>
                </center>
               </div>
               
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
                    <asp:GridView ID ="gvGraph" runat ="server" 
                    AllowSorting ="true"
                    CssClass ="gvStyle" OnRowDataBound="gvGraph_RowDataBound" 
                    OnSelectedIndexChanged="gvGraph_SelectedIndexChanged" OnSorting ="gvGraph_Sorting"
                    CurrentSortField ="" CurrentSortDirection ="ASC">
                    <Columns>
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                </asp:GridView>

                     <div style ="float : left">
                     <asp:Label ID ="lblPreviousPage" runat ="server" 
                        Text ="" CssClass="font_style"></asp:Label>
                     <br>
                      <asp:Button ID ="btPreviousPage" runat ="server" 
                        CssClass ="bt_Style" Text ="Предыдущая страница" OnClick="btPreviousPage_Click" />
                     </div>

                    <div style ="float : right">
                     <asp:Label ID ="lblNextPage" runat ="server" 
                        Text ="Результаты продаж" CssClass="font_style"></asp:Label>
                     <br>
                      <asp:Button ID ="btNextPage" runat ="server" 
                        CssClass ="bt_Style" Text ="Следующая страница" OnClick="btNextPage_Click" />
                    </div>
    </form>
</body>
</html>

