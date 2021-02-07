using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class Worker_Position : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrWorkerPosition;
            if (!IsPostBack)
            {
                gvFill(QR);
            }
        }

        private void gvFill(string qr)
        {
            sdsWorkerPosition.ConnectionString =
                DBConnection.connection.ConnectionString.ToString();
            sdsWorkerPosition.SelectCommand = qr;
            sdsWorkerPosition.DataSourceMode = SqlDataSourceMode.DataReader;
            gvWorkerPosition.DataSource = sdsWorkerPosition;
            gvWorkerPosition.DataBind();
        }

        protected void gvPosition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
        protected void gvPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvWorkerPosition.SelectedRow;
            tbPosition.Text = row.Cells[2].Text.ToString();
            tbSalary.Text = row.Cells[3].Text.ToString();
            DBConnection.IDpos = Convert.ToInt32(row.Cells[1].Text.ToString());
        }


        protected void btInsert_Click(object sender, EventArgs e)
        {
            switch (tbPosition.Text == "")
            {
                case (true):
                    tbPosition.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbPosition.BackColor = System.Drawing.Color.White;
                    switch (tbSalary.Text == "")
                    {
                        case (true):
                            tbSalary.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbSalary.BackColor = System.Drawing.Color.White;
                            SqlCommand command = new SqlCommand("", DBConnection.connection);
                            command.CommandText = "insert into [dbo].[Worker_Position] " +
                            "([Position], [Salary]) values ('" + tbPosition.Text + "', '" + tbSalary.Text + "')";
                            DBConnection.connection.Open();
                            command.ExecuteNonQuery();
                            DBConnection.connection.Close();
                            gvFill(QR);
                            break;
                    }
                    break;
            }
        } 
       

         protected void btUpdate_Click(object sender, EventArgs e)
            {
                switch (tbPosition.Text == "")
                {
                   case (true):
                     tbPosition.BackColor = System.Drawing.Color.Red;
                     break;
                   case (false):
                     tbPosition.BackColor = System.Drawing.Color.White;
                        switch (tbSalary.Text == "")
                             {
                               case (true):
                                 tbSalary.BackColor = System.Drawing.Color.Red;
                                 break;
                               case (false):
                                 tbSalary.BackColor = System.Drawing.Color.White;
                                 SqlCommand command = new SqlCommand("", DBConnection.connection);
                                 command.CommandText = "update [dbo].[Worker_Position] set " +
                                 "[Position] ='" + tbPosition.Text + "', " +
                                 "[Salary] ='" + tbSalary.Text + "', " + 
                                 " where ID_Position = " + DBConnection.IDpos + "";
                                 DBConnection.connection.Open();
                                 command.ExecuteNonQuery();
                                 DBConnection.connection.Close();
                                 gvFill(QR);
                                
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
                    command.CommandText = "delete from [dbo].[Worker_Position] " +
                        "where ID_Position = " + DBConnection.IDpos + "";
                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        } 

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvWorkerPosition.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text))
                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Position] like '%" + tbSearch.Text + "%' or " +
                "[Salary] like '%" + tbSearch.Text + "%'";
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
                case ("Должность"):
                    e.SortExpression = "[Position]";
                    break;
                case ("Оклад"):
                    e.SortExpression = "[Salary]";
                    break;
            }
            
            sortGridView(gvWorkerPosition, e, out sortDirection, out strField);
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