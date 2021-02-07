using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Authorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btEnter_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            connection.dbEnter(tbLogin.Text, tbPassword.Text);
            switch (DBConnection.IDuser)
            {
                case (0):
                    tbLogin.BackColor = System.Drawing.Color.Red;
                    tbPassword.BackColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Введён не верный логнин или пароль!";
                    tbPassword.Text = "";
                    tbLogin.Text = "";
                    break;
                default:
                    Response.Redirect("Sotrudnik Info.aspx");
                    break;
            }
        }

        protected void tbLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}