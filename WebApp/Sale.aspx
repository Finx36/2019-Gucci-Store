<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="WebApp.Sale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="Sale" runat="server">
        <asp:SqlDataSource ID = "sdsSalesResults" runat ="server"></asp:SqlDataSource>
         <center>
        <asp:Label ID ="lblTitle" runat ="server" Text= "Результаты продаж" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
        <br>
        <div style ="float : left">

             
            <asp:Label ID="lblRevenue" runat ="server"
             CssClass ="font_style" Text ="Выручка с товара"></asp:Label>
            <br>
            <asp:TextBox ID="tbRevenue" runat ="server"  CssClass ="tb_Style" Text ="" Width="259px"></asp:TextBox>
            <br>
            <asp:Label ID="lblCount" runat ="server"
             CssClass ="font_style" Text ="Кол-во продано"></asp:Label>
            <br>
            <asp:TextBox ID="tbCount" runat ="server"  CssClass ="tb_Style" Text ="" Width="259px"></asp:TextBox>
            <br>
            <asp:Label ID="lblConsumption" runat ="server"
             CssClass ="font_style" Text ="Расход на товар"></asp:Label>
            <br>
            <asp:TextBox ID="tbConsumption" runat ="server"  CssClass ="tb_Style" Text ="" Width="259px"></asp:TextBox>
            <br>
            <asp:Label ID="lbProduct" runat ="server"
             CssClass ="font_style" Text ="Товар"></asp:Label>
            <br>
            <asp:DropDownList ID="ddlProduct" runat="server">
            </asp:DropDownList>
            <br>
           <br>
            <center>
                <br>
             <asp:Button ID = "btInsert" runat ="server" CssClass ="bt_Style" 
                    Text ="Добавить новый отчёт" OnClick="btInsert_Click" /><br> 
                <asp:Button ID = "btUpdate" runat ="server" CssClass ="bt_Style" 
                    Text ="Изменить данные об отчёте" OnClick="btUpdate_Click" /><br>
                 <asp:Button ID = "btDelete" runat ="server" CssClass ="bt_Style" 
                    Text ="Удалить отчёт" OnClick="btDelete_Click" /><br>
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
                        CssClass ="bt_Style" Text ="Фильтр" OnClick="btFilter_Click" />
                    <asp:Button ID ="btCancel" runat ="server" 
                        CssClass ="bt_Style" Text ="Отмена" OnClick="btCancel_Click" />
                    <asp:GridView ID ="gvProduct" runat ="server" 
                    AllowSorting ="true"
                    CssClass ="gvStyle" OnRowDataBound="gvPosition_RowDataBound" 
                    OnSelectedIndexChanged="gvPosition_SelectedIndexChanged" OnSorting ="gvPosition_Sorting"
                    CurrentSortField ="" CurrentSortDirection ="ASC" >
                    <Columns>
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                </asp:GridView>

               <div style ="float : left">
                     <asp:Label ID ="lblPreviousPage" runat ="server" 
                        Text ="Список сотрудников" CssClass="font_style"></asp:Label>
                 <br>
                      <asp:Button ID ="btPreviousPage" runat ="server" 
                        CssClass ="bt_Style" Text ="Предыдущая страница" OnClick="btPreviousPage_Click" />
                 </div>

                 <div style ="float : right">
                     <asp:Label ID ="lblNextPage" runat ="server" 
                        Text ="Список рабочих дней" CssClass="font_style"></asp:Label>
                 <br>
                      <asp:Button ID ="btNextPage" runat ="server" 
                        CssClass ="bt_Style" Text ="Следующая страница" OnClick="btNextPage_Click" />
                 </div>

     </form>
</body>
</html>
