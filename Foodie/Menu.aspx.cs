using System;
using System.Data;
using System.Data.SqlClient;

namespace Foodie
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadMenu("", "");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMenu(txtSearch.Text.Trim(), ddlCategory.SelectedValue);
        }

        private void LoadMenu(string search, string category)
        {
            string query = "SELECT * FROM MenuItems WHERE Name LIKE @Search";
            if (!string.IsNullOrEmpty(category))
                query += " AND Category = @Category";

            SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("@Search", "%" + search + "%"),
                new SqlParameter("@Category", category)
            };

            DataTable dt = DBHelper.GetData(query, p);
            menuGrid.InnerHtml = "";

            foreach (DataRow row in dt.Rows)
            {
                string imgSrc = "Images/" + row["ImageFileName"].ToString();
                string html = $@"
                <div class='col-md-4 col-sm-6 mb-4'>
                  <div class='card h-100 border-0 shadow-sm'>
                    <img src='{imgSrc}' class='card-img-top' style='height:200px;object-fit:cover;'
                         onerror=""this.src='Images/default.jpg'"" />
                    <div class='card-body d-flex flex-column'>
                      <span class='badge mb-2' style='background:#c0392b;width:fit-content;'>{row["Category"]}</span>
                      <h5 class='card-title'>{row["Name"]}</h5>
                      <p class='card-text text-muted small'>{row["Description"]}</p>
                      <div class='mt-auto d-flex justify-content-between align-items-center'>
                        <span class='fw-bold fs-5' style='color:#c0392b;'>Rs. {row["Price"]}</span>
                        <a href='Cart.aspx?addItem={row["ItemID"]}' class='btn btn-sm text-white' style='background:#c0392b;'>
                          <i class='fas fa-plus me-1'></i>Add to Cart
                        </a>
                      </div>
                    </div>
                  </div>
                </div>";
                menuGrid.InnerHtml += html;
            }

            if (dt.Rows.Count == 0)
                menuGrid.InnerHtml = "<p class='text-muted'>No items found.</p>";
        }
    }
}