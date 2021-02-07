<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Worker_Position1.aspx.cs" Inherits="WebApp.Worker_Position" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="WorkerPosition" runat="server">
      <asp:SqlDataSource ID="sdsWorkerPosition" runat ="server"></asp:SqlDataSource>
        <center>
        <asp:Label ID ="lblTitle" runat ="server" Text= "Должность сотрудника" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
        <br>
        <div style ="float : left">
            <asp:Label ID="lblPosition" runat ="server"
             CssClass ="font_style" Text ="Должность сотрудника"></asp:Label>
            <br>
            <asp:TextBox ID="tbPosition" runat ="server"  CssClass ="tb_Style" Text ="Введите должность сотрудника" Width="259px"></asp:TextBox>
            <br>
            <asp:Label ID="lblSalary" runat ="server"
             CssClass ="font_style" Text ="Оклад"></asp:Label>
            <br>
            <asp:TextBox ID="tbSalary" runat ="server"  CssClass ="tb_Style" Text ="Введите сумму оклада" Width="259px" ></asp:TextBox>
           <br>
            <center>
                <br>
             <asp:Button ID = "btInsert" runat ="server" CssClass ="bt_Style" 
                    Text ="Добавить новую должность" OnClick="btInsert_Click" /><br> 
                <asp:Button ID = "btUpdate" runat ="server" CssClass ="bt_Style" 
                    Text ="Изменить данные о должности" OnClick="btUpdate_Click" /><br>
                 <asp:Button ID = "btDelete" runat ="server" CssClass ="bt_Style" 
                    Text ="Удалить должность" OnClick="btDelete_Click" /><br>
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
                    <br>
                    <asp:GridView ID ="gvWorkerPosition" runat ="server" 
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
