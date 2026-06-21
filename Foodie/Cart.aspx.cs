using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Foodie
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string addItem = Request.QueryString["addItem"];
            string removeItem = Request.QueryString["remove"];

            if (!string.IsNullOrEmpty(addItem))
            {
                int itemId;
                if (int.TryParse(addItem, out itemId))
                    AddToCart(itemId);
                Response.Redirect("Cart.aspx");
                return;
            }

            if (!string.IsNullOrEmpty(removeItem))
            {
                int removeId;
                if (int.TryParse(removeItem, out removeId))
                    RemoveFromCart(removeId);
                Response.Redirect("Cart.aspx");
                return;
            }

            ShowCart();
        }

        private void AddToCart(int itemId)
        {
            if (Session["Cart"] == null)
                Session["Cart"] = new Dictionary<int, int>();

            Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"];

            if (cart.ContainsKey(itemId))
                cart[itemId]++;
            else
                cart[itemId] = 1;

            Session["Cart"] = cart;
        }

        private void RemoveFromCart(int itemId)
        {
            if (Session["Cart"] == null) return;
            Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"];
            if (cart.ContainsKey(itemId))
                cart.Remove(itemId);
            Session["Cart"] = cart;
        }

        private void ShowCart()
        {
            if (Session["Cart"] == null || ((Dictionary<int, int>)Session["Cart"]).Count == 0)
            {
                phCart.Controls.Add(new LiteralControl(
                    "<div class='alert alert-info'>Your cart is empty. <a href='Menu.aspx'>Browse menu</a></div>"));
                return;
            }

            Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"];
            decimal total = 0;
            string rows = "";

            foreach (var item in cart)
            {
                DataTable dt = DBHelper.GetData(
                    "SELECT * FROM MenuItems WHERE ItemID=@ID",
                    new SqlParameter[] { new SqlParameter("@ID", item.Key) });

                if (dt.Rows.Count > 0)
                {
                    decimal price = Convert.ToDecimal(dt.Rows[0]["Price"]);
                    decimal sub = price * item.Value;
                    total += sub;
                    rows += $@"
                    <tr>
                      <td>{dt.Rows[0]["Name"]}</td>
                      <td>Rs. {price}</td>
                      <td>{item.Value}</td>
                      <td>Rs. {sub}</td>
                      <td><a href='Cart.aspx?remove={item.Key}' class='btn btn-sm btn-danger'>Remove</a></td>
                    </tr>";
                }
            }

            string html = $@"
            <div class='table-responsive'>
              <table class='table table-bordered'>
                <thead style='background:#c0392b;color:#fff;'>
                  <tr><th>Item</th><th>Price</th><th>Qty</th><th>Subtotal</th><th></th></tr>
                </thead>
                <tbody>{rows}</tbody>
                <tfoot>
                  <tr>
                    <td colspan='3' class='text-end fw-bold'>Total:</td>
                    <td colspan='2' class='fw-bold' style='color:#c0392b;'>Rs. {total}</td>
                  </tr>
                </tfoot>
              </table>
            </div>
            <div class='text-end mt-3'>
              <a href='Menu.aspx' class='btn btn-outline-secondary me-2'>Continue Shopping</a>
              <a href='Checkout.aspx' class='btn text-white' style='background:#c0392b;'>Proceed to Checkout</a>
            </div>";

            phCart.Controls.Add(new LiteralControl(html));
        }
    }
}