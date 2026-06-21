using System;
using System.Data.SqlClient;

namespace Foodie
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null) { Response.Redirect("AdminLogin.aspx"); return; }
            if (!IsPostBack) LoadItems();
        }

        private void LoadItems()
        {
            gvItems.DataSource = DBHelper.GetData(
                "SELECT ItemID, Name, Category, Price FROM MenuItems ORDER BY Category");
            gvItems.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Name and Price are required.";
                return;
            }

            DBHelper.ExecuteNonQuery(
                "INSERT INTO MenuItems (Name, Description, Price, Category, ImageFileName) VALUES (@N,@D,@P,@C,@I)",
                new SqlParameter[] {
                    new SqlParameter("@N", txtName.Text.Trim()),
                    new SqlParameter("@D", txtDesc.Text.Trim()),
                    new SqlParameter("@P", decimal.Parse(txtPrice.Text.Trim())),
                    new SqlParameter("@C", ddlCat.SelectedValue),
                    new SqlParameter("@I", txtImg.Text.Trim())
                });

            // Clear fields
            txtName.Text = "";
            txtDesc.Text = "";
            txtPrice.Text = "";
            txtImg.Text = "";

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "✅ Item added successfully!";

            LoadItems();
        }

        protected void gvItems_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                DBHelper.ExecuteNonQuery("DELETE FROM MenuItems WHERE ItemID=@ID",
                    new SqlParameter[] { new SqlParameter("@ID", id) });
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "✅ Item deleted.";
                LoadItems();
            }
        }
    }
}