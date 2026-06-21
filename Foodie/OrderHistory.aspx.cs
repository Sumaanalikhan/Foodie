using System;
using System.Data;
using System.Web.UI;

namespace Foodie
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null) { Response.Redirect("Login.aspx"); return; }

            int userId = Convert.ToInt32(Session["UserID"]);
            DataTable dt = DBHelper.GetData(
                "SELECT OrderID, OrderDate, TotalAmount, Status FROM Orders WHERE UserID=@UID ORDER BY OrderDate DESC",
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@UID", userId) });

            if (dt.Rows.Count == 0)
            {
                phOrders.Controls.Add(new LiteralControl("<div class='alert alert-info'>No orders yet. <a href='Menu.aspx'>Order now!</a></div>"));
                return;
            }

            string rows = "";
            foreach (DataRow row in dt.Rows)
            {
                string statusColor = row["Status"].ToString() == "Delivered" ? "success" : "warning";
                rows += $@"<tr>
                    <td>#{row["OrderID"]}</td>
                    <td>{Convert.ToDateTime(row["OrderDate"]).ToString("dd MMM yyyy, hh:mm tt")}</td>
                    <td>Rs. {row["TotalAmount"]}</td>
                    <td><span class='badge bg-{statusColor}'>{row["Status"]}</span></td>
                </tr>";
            }

            phOrders.Controls.Add(new LiteralControl(
                $"<div class='table-responsive'><table class='table table-striped'><thead style='background:#c0392b;color:#fff;'>" +
                $"<tr><th>Order #</th><th>Date</th><th>Total</th><th>Status</th></tr></thead><tbody>{rows}</tbody></table></div>"));
        }
    }
}