using System;
namespace Foodie
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin" && txtPass.Text == "admin123")
            {
                Session["IsAdmin"] = true;
                Response.Redirect("AdminPanel.aspx");
            }
            else lblMsg.Text = "Invalid credentials.";
        }
    }
}