using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GucciWPF
{
    class DBConnection
    {
        public static SqlConnection connection = new SqlConnection(
            @"Data Source = BOROV\SQLEXPRESS; " +
                " Initial Catalog = Gucci; Integrated Security=SSPI;");
        public DataTable dtProjects = new DataTable("Projects");
        public DataTable dtSalesResults = new DataTable("SalesResults");
        public DataTable dtProduct = new DataTable("Product");
        public DataTable dtSotrudniki = new DataTable("Sotrudniki");
        public DataTable dtWorkerPosition = new DataTable("WorkerPosition");

        public static string qrProjects = "SELECT [ID_Project], [Name_Of_Project] , " +
        "[Cost], [Duration] , " +
        "[dbo].[Projects].[Sotrudnik_ID], [Surname], " +
        "[Name] , [Middle_Name] , [dbo].[Projects].[Result_ID], " +
        " [Product_Revenue] , " +
        " [Count_Sold] , [Consumption_Of_Product] FROM [dbo].[Projects] " +
        "INNER JOIN [dbo].[Sotrudniki] " +
        "ON [dbo].[Projects].[Sotrudnik_ID]" +
        "= [dbo].[Sotrudniki].[ID_Sotrudnik]" +
        "INNER JOIN [dbo].[Sales_Results] " +
        "ON [dbo].[Projects].[Result_ID]" +
        "= [dbo].[Sales_Results].[ID_Result]";

        public static string qrSalesResults = "SELECT [ID_Result], [Product_Revenue] , " +
        "[Count_Sold] , [Consumption_Of_Product] , " +
        "[dbo].[Sales_Results].[Product_ID], [Product_Name]  FROM [dbo].[Sales_Results] " +
        "INNER JOIN [dbo].[Product] " +
        "ON [dbo].[Sales_Results].[Product_ID] " +
        "= [dbo].[Product].[ID_Product]";

        public static string qrProduct = "SELECT [ID_Product], [Product_Name], " +
        "[Price] , [Type_Of_Product]  FROM [dbo].[Product]";

        public static string qrSotrudniki = "SELECT [ID_Sotrudnik], [Surname] , " +
        "[Name] , [Middle_Name]  " +
        ",[Date_Of_Birth] , [Passport_Number], [Passport_Series], " +
        "[User_Name] ,[Password] , " +
        " [dbo].[Sotrudniki].[Position_ID], [Position] , [Salary]  FROM [dbo].[Sotrudniki] " +
        " INNER JOIN [dbo].[Worker_Position] " +
        "ON [dbo].[Sotrudniki].[Position_ID] " +
        "= [dbo].[Worker_Position].[ID_Position]";

        public static string qrWorkerPosition = "SELECT [ID_Position], [Position] , " +
            "[Salary] FROM [dbo].[Worker_Position]";

        private SqlCommand command = new SqlCommand("", connection);
        public static Int32 IDsotrudnik, IDgrap, IDvehicle, IDpos, IDUser, IDproject;

        public void dbEnter(string login, string password)
        {
            command.CommandText = "SELECT count(*) FROM [dbo].[Sotrudniki] " +
                "where [User_Name] = '" + login + "' and [Password] = '" +
                password + "'";
            connection.Open();
            IDUser = Convert.ToInt32(command.ExecuteScalar().ToString());
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
