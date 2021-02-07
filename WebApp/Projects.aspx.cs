using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
            private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrProjects;
            if (!IsPostBack)
            {
                gvFill(QR);
                ddlSotrudnikFill();
                ddlSalesResultFill();
            }
        }

        private void gvFill(string qr)
        {
            sdsProject.ConnectionString =
                DBConnection.connection.ConnectionString.ToString();
            sdsProject.SelectCommand = qr;
            sdsProject.DataSourceMode = SqlDataSourceMode.DataReader;
            gvProject.DataSource = sdsProject;
            gvProject.DataBind();
        }

        private void ddlSotrudnikFill()
        {
            sdsProject.ConnectionString =
            DBConnection.connection.ConnectionString.ToString();
            sdsProject.SelectCommand = DBConnection.qrSotrudniki;
            sdsProject.DataSourceMode = SqlDataSourceMode.DataReader;
            ddlSotrudnik.DataSource = sdsProject;
            ddlSotrudnik.DataTextField = "Фамилия";
            ddlSotrudnik.DataValueField = "ID_Sotrudnik";
            ddlSotrudnik.DataBind();
        }

        private void ddlSalesResultFill()
        {
            sdsProject.ConnectionString =
            DBConnection.connection.ConnectionString.ToString();
            sdsProject.SelectCommand = DBConnection.qrSalesResults;
            sdsProject.DataSourceMode = SqlDataSourceMode.DataReader;
            ddlSalesResult.DataSource = sdsProject;
            ddlSalesResult.DataTextField = "Выручка с товара";
            ddlSalesResult.DataValueField = "ID_Result";
            ddlSalesResult.DataBind();
        }

        protected void gvWorker_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void gvWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvProject.SelectedRow;
            tbProjectName.Text = row.Cells[2].Text.ToString();
            tbCost.Text = row.Cells[3].Text.ToString();
            tbDuration.Text = row.Cells[4].Text.ToString();
            ddlSotrudnik.SelectedValue = row.Cells[5].Text;
            ddlSalesResult.SelectedValue = row.Cells[9].Text;
            DBConnection.IDproject = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            switch (tbProjectName.Text == "")
            {
                case (true):
                    tbProjectName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbProjectName.BackColor = System.Drawing.Color.White;
                    switch (tbCost.Text == "")
                    {
                        case (true):
                            tbCost.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbCost.BackColor = System.Drawing.Color.White;
                            switch (tbDuration.Text == "")
                            {
                                case (true):
                                    tbDuration.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbDuration.BackColor = System.Drawing.Color.White;
                                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                                    command.CommandText = "insert into [dbo].[Projects] " +
                                    "([Name_Of_Project], [Cost], [Duration], [Sotrudnik_ID], [Result_ID]) values ('" + tbProjectName.Text + "','" + tbCost.Text + "','" + tbDuration.Text + "', '" + ddlSotrudnik.SelectedValue + "', '" + ddlSalesResult.SelectedValue + "')";
                                    DBConnection.connection.Open();
                                    command.ExecuteNonQuery();
                                    DBConnection.connection.Close();
                                    gvFill(QR);
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }


        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbProjectName.Text == "")
            {
                case (true):
                    tbProjectName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbProjectName.BackColor = System.Drawing.Color.White;
                    switch (tbCost.Text == "")
                    {
                        case (true):
                            tbCost.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbCost.BackColor = System.Drawing.Color.White;
                            switch (tbDuration.Text == "")
                            {
                                case (true):
                                    tbDuration.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbDuration.BackColor = System.Drawing.Color.White;
                                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                                    command.CommandText = "update [dbo].[Projects] set " +
                                   "[Name_Of_Project] ='" + tbProjectName.Text + "', " +
                                   "[Cost] ='" + tbCost.Text + "', " +
                                   "[Duration] ='" + tbDuration.Text + "'" +
                                   "[Sotrudnik_ID]='" + ddlSotrudnik.SelectedValue + "'" +
                                   "[Result_ID]='" + ddlSalesResult.SelectedValue + "'" +
                                   " where ID_Project = " + DBConnection.IDproject + "";
                                    DBConnection.connection.Open();
                                    command.ExecuteNonQuery();
                                    DBConnection.connection.Close();
                                    gvFill(QR);
                                    break;
                            }
                            break;
                    }
                    break;

            }
        }


        protected void btDelete_Click(object sender, EventArgs e)
        {
            switch (System.Windows.Forms.MessageBox.Show(
                "Удалить выбранную запись?", "Удаление записи",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "delete from [dbo].[Projects] " +
                        "where ID_Project = " + DBConnection.IDproject + "";
                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    Page_Load(sender, e);
                    break;
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvProject.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[5].Text.Equals(tbSearch.Text)
                    || row.Cells[6].Text.Equals(tbSearch.Text)
                    || row.Cells[7].Text.Equals(tbSearch.Text)
                    || row.Cells[8].Text.Equals(tbSearch.Text)
                    || row.Cells[12].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Name_Of_Project] like '%" + tbSearch.Text + "%' or " +
                "[Cost] like '%" + tbSearch.Text + "%' or " +
                "[Duration] like '%" + tbSearch.Text + "%' or " +
                "[Surname] like '%" + tbSearch.Text + "%' or " +
                "[Name] like '%" + tbSearch.Text + "%' or " +
                "[Middle_Name] like '%" + tbSearch.Text + "%' or " +
                "[Product_Name] like '%" + tbSearch.Text + "%' or " +
                "[Count_Sold] like '%" + tbSearch.Text + "%' or " +
                "[Product_Revenue] like '%" + tbSearch.Text + "%' or " +
                "[Consumption_Of_Product] like '%" + tbSearch.Text + "%'"; 
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }

        protected void gvWorker_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Фамилия"):
                    e.SortExpression = "[Surname]";
                    break;
                case ("Имя"):
                    e.SortExpression = "[Name]";
                    break;
                case ("Отчество"):
                    e.SortExpression = "[Middle_Name]";
                    break;
                case ("Дата рождения"):
                    e.SortExpression = "[Date_Of_Birth]";
                    break;
                case ("Номер паспорта"):
                    e.SortExpression = "[Passport_Number]";
                    break;
                case ("Серия паспорта"):
                    e.SortExpression = "[Passport_Series]";
                    break;
                case ("Логин"):
                    e.SortExpression = "[User_Name]";
                    break;
                case ("Должность"):
                    e.SortExpression = "[Position]";
                    break;
                case ("Оклад"):
                    e.SortExpression = "[Salary]";
                    break;
            }
            sortGridView(gvProject, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        public void sortGridView(GridView gridView,
            GridViewSortEventArgs e,
            out SortDirection sortDirection,
            out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }
        protected void btPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vehicle.aspx");
        }

        protected void btNextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Worker_Position.aspx");
        }


    }
}