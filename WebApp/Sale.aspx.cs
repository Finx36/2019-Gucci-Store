using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApp
{
    public partial class Sale : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrSalesResults;
            if (!IsPostBack)
            {
                gvFill(QR);
                ddlFill();
            }
        }

        private void gvFill(string qr)
        {
            sdsSalesResults.ConnectionString =
                DBConnection.connection.ConnectionString.ToString();
            sdsSalesResults.SelectCommand = qr;
            sdsSalesResults.DataSourceMode = SqlDataSourceMode.DataReader;
            gvProduct.DataSource = sdsSalesResults;
            gvProduct.DataBind();
        }

        private void ddlFill()
        {
            sdsSalesResults.ConnectionString =
                DBConnection.connection.ConnectionString.ToString();
            sdsSalesResults.SelectCommand = DBConnection.qrProduct;
            sdsSalesResults.DataSourceMode = SqlDataSourceMode.DataReader;
            ddlProduct.DataSource = sdsSalesResults;
            ddlProduct.DataTextField = "Название товара";
            ddlProduct.DataValueField = "ID_Product";
            ddlProduct.DataBind();
        }

        protected void gvPosition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[5].Visible = false;
        }
        protected void gvPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvProduct.SelectedRow;
            tbRevenue.Text = row.Cells[2].Text.ToString();
            tbCount.Text = row.Cells[3].Text.ToString();
            tbConsumption.Text = row.Cells[4].Text.ToString();
            ddlProduct.SelectedValue = row.Cells[5].Text;
            DBConnection.IDpos = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            switch (tbRevenue.Text == "")
            {
                case (true):
                    tbRevenue.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbRevenue.BackColor = System.Drawing.Color.White;
                    switch (tbCount.Text == "")
                    {
                        case (true):
                            tbCount.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbCount.BackColor = System.Drawing.Color.White;
                            switch (tbConsumption.Text == "")
                            {
                                case (true):
                                    tbConsumption.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbConsumption.BackColor = System.Drawing.Color.White;
                                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                                    command.CommandText = "insert into [dbo].[Sales_Results] " +
                                    "([Product_Revenue], [Count_Sold], [Consumption_Of_Product], [Product_ID]) values ('" + tbRevenue.Text + "', '" + tbCount.Text + "',  '" + tbConsumption.Text + "','" + ddlProduct.SelectedValue + "')"; 
                                    DBConnection.connection.Open();
                                    command.ExecuteNonQuery();
                                    DBConnection.connection.Close();
                                    gvFill(QR);
                                    ddlFill();
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }


        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbRevenue.Text == "")
            {
                case (true):
                    tbRevenue.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbRevenue.BackColor = System.Drawing.Color.White;
                    switch (tbCount.Text == "")
                    {
                        case (true):
                            tbCount.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbCount.BackColor = System.Drawing.Color.White;
                            switch (tbConsumption.Text == "")
                            {
                                case (true):
                                    tbConsumption.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbConsumption.BackColor = System.Drawing.Color.White;
                                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                                    command.CommandText = "update [dbo].[Sales_Results] set " +
                                    "[Product_Revenue] ='" + tbRevenue.Text + "', " +
                                    "[Count_Sold] ='" + tbCount.Text + "', " +
                                    "[Consumption_Of_Product] ='" + tbConsumption.Text + "', " +
                                    "[Product_ID]='" + ddlProduct.SelectedValue + "'" +
                                    " where ID_Result = " + DBConnection.IDpos + "";
                                    DBConnection.connection.Open();
                                    command.ExecuteNonQuery();
                                    DBConnection.connection.Close();
                                    gvFill(QR);
                                    ddlFill();
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
                    command.CommandText = "delete from [dbo].[Sales_Results] " +
                        "where ID_Product = " + DBConnection.IDpos + "";
                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    gvFill(QR);
                    ddlFill();
                    break;
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvProduct.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[6].Text.Equals(tbSearch.Text))


                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Product_Revenue] like '%" + tbSearch.Text + "%' or " +
                "[Count_Sold] like '%" + tbSearch.Text + "%' or " +
                "[Consumption_Of_Product] like '%" + tbSearch.Text + "%' or " +
                "[Product_Name] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }

        protected void gvPosition_Sorting(object sender, GridViewSortEventArgs e)
        {

            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;

            switch (e.SortExpression)
            {
                case ("Выручка с товара"):
                    e.SortExpression = "[Product_Revenue]";
                    break;
                case ("Кол-во продано"):
                    e.SortExpression = "[Count_Sold]";
                    break;
                case ("Расход на товар"):
                    e.SortExpression = "[Consumption_Of_Product]";
                    break;
                case ("Название товара"):
                    e.SortExpression = "[Product_Name]";
                    break;
            }

            sortGridView(gvProduct, e, out sortDirection, out strField);
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
            Response.Redirect("Sotrudnik Info.aspx");
        }

        protected void btNextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Graph.aspx");
        }
    }
}
    