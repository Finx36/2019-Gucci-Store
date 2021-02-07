using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrProduct;
            if (!IsPostBack)
            {
                gvFill(QR);
            }
        }

        public void gvFill(string qr)
        {
            sdsGraph.ConnectionString =
                DBConnection.connection.ConnectionString.ToString();
            sdsGraph.SelectCommand = qr;
            sdsGraph.DataSourceMode = SqlDataSourceMode.DataReader;
            gvGraph.DataSource = sdsGraph;
            gvGraph.DataBind();
        }

        protected void gvGraph_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
        protected void gvGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvGraph.SelectedRow;
            tbProductName.Text = row.Cells[2].Text.ToString();
            tbPrice.Text = row.Cells[3].Text.ToString();
            tbType.Text = row.Cells[4].Text.ToString();
            DBConnection.IDgrap = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            switch (tbProductName.Text == "")
            {
                case (true):
                    tbProductName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbProductName.BackColor = System.Drawing.Color.White;
                    switch (tbPrice.Text == "")
                    {
                        case (true):
                            tbPrice.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbPrice.BackColor = System.Drawing.Color.White;
                            switch (tbType.Text == "")
                            {
                                case (true):
                                    tbType.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbType.BackColor = System.Drawing.Color.White;
                                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                                    command.CommandText = "insert into [dbo].[Product] " +
                                    "([Product_Name],[Price],[Type_Of_Product]) values ('" + tbProductName.Text + "','" + tbPrice.Text + "','" + tbType.Text + "')";
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
            switch (tbProductName.Text == "")
            {
                case (true):
                    tbProductName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbProductName.BackColor = System.Drawing.Color.White;
                    switch (tbPrice.Text == "")
                    {
                        case (true):
                            tbPrice.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbPrice.BackColor = System.Drawing.Color.White;
                            switch (tbType.Text == "")
                            {
                                case (true):
                                    tbType.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbType.BackColor = System.Drawing.Color.White;
                                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                                    command.CommandText = "update [dbo].[Product] set " +
                                   "[Product_Name] ='" + tbProductName.Text + "', " +
                                   "[Price] ='" + tbPrice.Text + "', " +
                                   "[Type_Of_Product] ='" + tbType.Text + "'" +
                                   " where ID_Product = " + DBConnection.IDgrap + "";
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
                    command.CommandText = "delete from [dbo].[Product] " +
                        "where ID_Product = " + DBConnection.IDgrap + "";
                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        } 

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvGraph.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text))
                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + "where [Product_Name] like '%" + tbSearch.Text + "%' or " +
            "[Price] like '%" + tbSearch.Text + "%' or " +
            "[Type_Of_Product] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }

        protected void gvGraph_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Название товара"):
                    e.SortExpression = "[Product_Name]";
                    break;
                case ("Цена"):
                    e.SortExpression = "[Price]";
                    break;
                case ("Тип"):
                    e.SortExpression = "[Type_Of_Product]";
                    break;
            }
            sortGridView(gvGraph, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        private void sortGridView(GridView gridView,
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
            Response.Redirect("Worker_Position.aspx");
        }

        protected void btNextPage_Click(object sender, EventArgs e)
        {
           Response.Redirect("Vehicle.aspx");
        }
    }
}