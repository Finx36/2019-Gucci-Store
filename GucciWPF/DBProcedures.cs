using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GucciWPF
{
    class DBProcedures
    {
        private SqlCommand command = new SqlCommand("", DBConnection.connection);

        private void commandConfig(string config)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        public void gucDolgnost_insert(string Position, Int32 Salary)
        {
            commandConfig("Worker_Position_insert");

            command.Parameters.AddWithValue("@Position", Position);
            command.Parameters.AddWithValue("@Salary", Salary);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucDolgnost_update(Int32 ID_Position,string Position, Int32 Salary)
        {
            commandConfig("Worker_Position_update");

            command.Parameters.AddWithValue("@ID_Position", ID_Position);
            command.Parameters.AddWithValue("@Position", Position);
            command.Parameters.AddWithValue("@Salary", Salary);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucDolgnost_delete(Int32 ID_Position)
        {
            commandConfig("Worker_Position_delete");

            command.Parameters.AddWithValue("@ID_Position", ID_Position);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucSotrudniki_insert(string Surname, string Name, string Middle_Name, string Date_OF_Birth, Int32 Passport_Number, Int32 Passport_Series, string User_Name, string Password, Int32 Position_ID)
        {
            commandConfig("Sotrudniki_insert");

            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Middle_Name", Middle_Name);
            command.Parameters.AddWithValue("@Date_OF_Birth", Date_OF_Birth);
            command.Parameters.AddWithValue("@Passport_Number", Passport_Number);
            command.Parameters.AddWithValue("@Passport_Series", Passport_Series);
            command.Parameters.AddWithValue("@User_Name", User_Name);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Position_ID", Position_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucSotrudniki_update(Int32 ID_Sotrudnik, string Surname, string Name, string Middle_Name, string Date_OF_Birth, Int32 Passport_Number, Int32 Passport_Series, string User_Name, string Password, Int32 Position_ID)
        {
            commandConfig("Sotrudniki_update");

            command.Parameters.AddWithValue("@ID_Sotrudnik", ID_Sotrudnik);
            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Middle_Name", Middle_Name);
            command.Parameters.AddWithValue("@Date_OF_Birth", Date_OF_Birth);
            command.Parameters.AddWithValue("@Passport_Number", Passport_Number);
            command.Parameters.AddWithValue("@Passport_Series", Passport_Series);
            command.Parameters.AddWithValue("@User_Name", User_Name);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Position_ID", Position_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucSotrudniki_delete(Int32 ID_Sotrudnik)
        {
            commandConfig("Sotrudniki_delete");

            command.Parameters.AddWithValue("@ID_Sotrudnik", ID_Sotrudnik);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucProduct_insert(string Product_Name, Int32 Price, string Type_Of_Product)
        {
            commandConfig("Product_insert");

            command.Parameters.AddWithValue("@Product_Name", Product_Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Type_Of_Product", Type_Of_Product);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucProduct_update(Int32 ID_Product, string Product_Name, Int32 Price, string Type_Of_Product)
        {
            commandConfig("Product_update");

            command.Parameters.AddWithValue("@ID_Product", ID_Product);
            command.Parameters.AddWithValue("@Product_Name", Product_Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Type_Of_Product", Type_Of_Product);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucProduct_delete(Int32 ID_Product)
        {
            commandConfig("Product_delete");

            command.Parameters.AddWithValue("@ID_Product", ID_Product);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucSales_Results_insert(Int32 Product_Revenue, Int32 Count_Sold, Int32 Consumption_Of_Product, Int32 Product_ID)
        {
            commandConfig("Sales_Results_insert");

            command.Parameters.AddWithValue("@Product_Revenue", Product_Revenue);
            command.Parameters.AddWithValue("@Count_Sold", Count_Sold);
            command.Parameters.AddWithValue("@Consumption_Of_Product", Consumption_Of_Product);
            command.Parameters.AddWithValue("@Product_ID", Product_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucSales_Results_update(Int32 ID_Result, Int32 Product_Revenue, Int32 Count_Sold, Int32 Consumption_Of_Product, Int32 Product_ID)
        {
            commandConfig("Sales_Results_update");

            command.Parameters.AddWithValue("@ID_Result", ID_Result);
            command.Parameters.AddWithValue("@Product_Revenue", Product_Revenue);
            command.Parameters.AddWithValue("@Count_Sold", Count_Sold);
            command.Parameters.AddWithValue("@Consumption_Of_Product", Consumption_Of_Product);
            command.Parameters.AddWithValue("@Product_ID", Product_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucSales_Results_delete(Int32 ID_Result)
        {
            commandConfig("Sales_Results_delete");

            command.Parameters.AddWithValue("@ID_Result", ID_Result);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucProjects_insert(string Name_Of_Project, Int32 Cost, string Duration, Int32 Sotrudnik_ID, Int32 Result_ID)
        {
            commandConfig("Projects_insert");

            command.Parameters.AddWithValue("@Name_Of_Project", Name_Of_Project);
            command.Parameters.AddWithValue("@Cost", Cost);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Sotrudnik_ID", Sotrudnik_ID);
            command.Parameters.AddWithValue("@Result_ID", Result_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucProjects_update(Int32 ID_Project, string Name_Of_Project, Int32 Cost, string Duration, Int32 Sotrudnik_ID, Int32 Result_ID)
        {
            commandConfig("Projects_update");

            command.Parameters.AddWithValue("ID_Project", ID_Project);
            command.Parameters.AddWithValue("@Name_Of_Project", Name_Of_Project);
            command.Parameters.AddWithValue("@Cost", Cost);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Sotrudnik_ID", Sotrudnik_ID);
            command.Parameters.AddWithValue("@Result_ID", Result_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void gucProjects_delete(Int32 ID_Project)
        {
            commandConfig("Projects_delete");

            command.Parameters.AddWithValue("ID_Project", ID_Project);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
    }
}
