using System;
using System.Data.SqlClient;

namespace Foodie
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (name == "" || email == "" || pass == "")
            {
                lblMsg.Text = "All fields are required.";
                return;
            }

            string query = "INSERT INTO Users (FullName, Email, Password) VALUES (@Name, @Email, @Pass)";
            try
            {
                DBHelper.ExecuteNonQuery(query, new SqlParameter[] {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Pass", pass)
                });
                Response.Redirect("Login.aspx");
            }
            catch
            {
                lblMsg.Text = "Email already exists or an error occurred.";
            }
        }
    }
}