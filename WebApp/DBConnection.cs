using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace WebApp
{
    public class DBConnection
    {
        public static SqlConnection connection = new SqlConnection(
            @"Data Source = BOROV\SQLEXPRESS; " +
                " Initial Catalog = Gucci; Persist Security Info = true;" +
                " User ID = sa; Password = \"\"");
        public DataTable dtProjects = new DataTable("Projects");
        public DataTable dtSalesResults = new DataTable("SalesResults");
        public DataTable dtProduct = new DataTable("Product");
        public DataTable dtSotrudniki = new DataTable("Sotrudniki");
        public DataTable dtWorkerPosition = new DataTable("WorkerPosition");

        public static string qrProjects = "SELECT [ID_Project], [Name_Of_Project] as \"Название проекта\", " +
        "[Cost] as \"Стоимость\", [Duration] as \"Длительность\", " +
        "[dbo].[Projects].[Sotrudnik_ID], [Surname] as \"Фамилия\", " +
        "[Name] as \"Имя\", [Middle_Name] as \"Отчество\", [dbo].[Projects].[Result_ID], " +
        " [Product_Revenue] as \"Выручка с товара\", " +
        " [Count_Sold] as \"Кол-во продано\", [Consumption_Of_Product] as \"Расход на товар\" FROM [dbo].[Projects] " +
        "INNER JOIN [dbo].[Sotrudniki] " +
        "ON [dbo].[Projects].[Sotrudnik_ID]" +
        "= [dbo].[Sotrudniki].[ID_Sotrudnik]" +
        "INNER JOIN [dbo].[Sales_Results] " +
        "ON [dbo].[Projects].[Result_ID]" +
        "= [dbo].[Sales_Results].[ID_Result]";

        public static string qrSalesResults = "SELECT [ID_Result], [Product_Revenue] as \"Выручка с товара\", " +
        "[Count_Sold] as \"Количество продано\", [Consumption_Of_Product] as \"Расход на товар\", " +
        "[dbo].[Sales_Results].[Product_ID], [Product_Name] as \"Название товара\" FROM [dbo].[Sales_Results] " +
        "INNER JOIN [dbo].[Product] " +
        "ON [dbo].[Sales_Results].[Product_ID] " +
        "= [dbo].[Product].[ID_Product]";

        public static string qrProduct = "SELECT [ID_Product], [Product_Name] as \"Название товара\", " +
        "[Price] as \"Цена\", [Type_Of_Product] as \"Тип товара\" FROM [dbo].[Product]";

        public static string qrSotrudniki = "SELECT [ID_Sotrudnik], [Surname] as \"Фамилия\", " +
        "[Name] as \"Имя\", [Middle_Name] as \"Отчество\" " +
        ",[Date_Of_Birth] as \"Дата рождения\", [Passport_Number] as \"Номер паспорта\", [Passport_Series] as \"Серия паспорта\", " +
        "[User_Name] as \"Логин\",[Password] as \"Пароль\", " +
        " [dbo].[Sotrudniki].[Position_ID], [Position] as \"Должность\", [Salary] as \"Оклад\" FROM [dbo].[Sotrudniki] " +
        " INNER JOIN [dbo].[Worker_Position] " +
        "ON [dbo].[Sotrudniki].[Position_ID] " +
        "= [dbo].[Worker_Position].[ID_Position]";

        public static string qrWorkerPosition = "SELECT [ID_Position], [Position] as \"Должность\", " +
            "[Salary] as \"Оклад\" FROM [dbo].[Worker_Position]";

        private SqlCommand command = new SqlCommand("", connection);
        public static Int32 IDsotrudnik, IDgrap, IDvehicle, IDpos, IDuser, IDproject;

        public void dbEnter(string login, string password)
        {
            command.CommandText = "SELECT count(*) FROM [dbo].[Sotrudniki] " +
                "where [User_Name] = '" + login + "' and [Password] = '" +
                password + "'";
            connection.Open();
            IDuser = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }

        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

        public void ProjectsFill()
        {
            dtFill(dtProjects, qrProjects);
        }

        public void SotrudnikFill()
        {
            dtFill(dtSotrudniki, qrSotrudniki);
        }

        public void ProductFill()
        {
            dtFill(dtProduct, qrProduct);
        }

        public void SalesResultsFill()
        {
            dtFill(dtSalesResults, qrSalesResults);
        }

        public void PositionFill()
        {
            dtFill(dtWorkerPosition, qrWorkerPosition);
        }
    }
}