using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Foodie
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (!IsPostBack)
                ShowSummary();
        }

        private void ShowSummary()
        {
            if (Session["Cart"] == null || ((Dictionary<int, int>)Session["Cart"]).Count == 0)
            {
                phSummary.Controls.Add(new LiteralControl("<div class='alert alert-info'>Your cart is empty. <a href='Menu.aspx'>Browse menu</a></div>"));
                btnPlace.Visible = false;
                return;
            }

            Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"];
            decimal total = 0;
            string rows = "";

            foreach (var item in cart)
            {
                DataTable dt = DBHelper.GetData("SELECT * FROM MenuItems WHERE ItemID=@ID",
                    new SqlParameter[] { new SqlParameter("@ID", item.Key) });
                if (dt.Rows.Count > 0)
                {
                    decimal price = Convert.ToDecimal(dt.Rows[0]["Price"]);
                    decimal sub = price * item.Value;
                    total += sub;
                    rows += $"<tr><td>{dt.Rows[0]["Name"]}</td><td>x{item.Value}</td><td>Rs. {sub}</td></tr>";
                }
            }

            phSummary.Controls.Add(new LiteralControl(
                $"<table class='table'><thead style='background:#c0392b;color:#fff;'><tr><th>Item</th><th>Qty</th><th>Amount</th></tr></thead>" +
                $"<tbody>{rows}</tbody>" +
                $"<tfoot><tr><td colspan='2' class='fw-bold'>Total</td><td class='fw-bold' style='color:#c0392b;'>Rs. {total}</td></tr></tfoot></table>"));
        }

        protected void btnPlace_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] == null) return;

            Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"];
            if (cart.Count == 0) return;

            int userId = Convert.ToInt32(Session["UserID"]);
            decimal total = 0;

            foreach (var item in cart)
            {
                DataTable dt = DBHelper.GetData("SELECT Price FROM MenuItems WHERE ItemID=@ID",
                    new SqlParameter[] { new SqlParameter("@ID", item.Key) });
                if (dt.Rows.Count > 0)
                    total += Convert.ToDecimal(dt.Rows[0]["Price"]) * item.Value;
            }

            string insertOrder = "INSERT INTO Orders (UserID, TotalAmount) VALUES (@UID, @Total); SELECT SCOPE_IDENTITY()";
            int orderId = Convert.ToInt32(DBHelper.ExecuteScalar(insertOrder, new SqlParameter[] {
                new SqlParameter("@UID", userId),
                new SqlParameter("@Total", total)
            }));

            foreach (var item in cart)
            {
                DataTable dt = DBHelper.GetData("SELECT Price FROM MenuItems WHERE ItemID=@ID",
                    new SqlParameter[] { new SqlParameter("@ID", item.Key) });
                if (dt.Rows.Count > 0)
                {
                    DBHelper.ExecuteNonQuery(
                        "INSERT INTO OrderItems (OrderID,ItemID,Quantity,UnitPrice) VALUES (@OID,@IID,@Qty,@Price)",
                        new SqlParameter[] {
                            new SqlParameter("@OID", orderId),
                            new SqlParameter("@IID", item.Key),
                            new SqlParameter("@Qty", item.Value),
                            new SqlParameter("@Price", Convert.ToDecimal(dt.Rows[0]["Price"]))
                        });
                }
            }

            Session.Remove("Cart");
            lblMsg.Text = "✅ Order placed successfully! Your Order # is " + orderId;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            btnPlace.Enabled = false;
        }
    }
}