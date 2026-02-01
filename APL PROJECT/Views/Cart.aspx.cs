using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

    public partial class Views_Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }

        private void LoadCartItems()
        {
            List<int> cart = Session["Cart"] as List<int>;
            if (cart == null || cart.Count == 0)
            {
                gvCart.DataSource = null;
                gvCart.DataBind();
                lblTotal.Text = "Your cart is empty.";
                btnCheckout.Visible = false;
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(cs))
            {
                string ids = string.Join(",", cart.Select(i => i.ToString()).Distinct());

                SqlCommand cmd = new SqlCommand("SELECT ProductID, Name, Price FROM Products WHERE ProductID IN (" + ids + ")", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            gvCart.DataSource = dt;
            gvCart.DataBind();

            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["Price"]);
            }

            lblTotal.Text = "Total: Rs " + total.ToString("N2");
        }

        protected void gvCart_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                List<int> cart = Session["Cart"] as List<int>;

                if (cart != null)
                {
                    cart.Remove(productId);
                    Session["Cart"] = cart;
                    LoadCartItems();
                }
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("Login.aspx");

            Response.Redirect("Checkout.aspx");
        }
    }