using System;
using System.Data;
using System.Data.SqlClient;

namespace Foodie
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pass = txtPass.Text.Trim();

            string query = "SELECT UserID, FullName FROM Users WHERE Email=@Email AND Password=@Pass";
            DataTable dt = DBHelper.GetData(query, new SqlParameter[] {
                new SqlParameter("@Email", email),
                new SqlParameter("@Pass", pass)
            });

            if (dt.Rows.Count > 0)
            {
                Session["UserID"] = dt.Rows[0]["UserID"];
                Session["UserName"] = dt.Rows[0]["FullName"];
                Response.Redirect("Menu.aspx");
            }
            else
            {
                lblMsg.Text = "Invalid email or password.";
            }
        }
    }
}