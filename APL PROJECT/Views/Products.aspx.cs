using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
    public partial class Views_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products ORDER BY ProductID ", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                rptAllProducts.DataSource = dt;
                rptAllProducts.DataBind();
            }
        }

        protected void btnAddToCart_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int productId = Convert.ToInt32(e.CommandArgument);
            List<int> cart = Session["Cart"] as List<int> ?? new List<int>();

            cart.Add(productId);
            Session["Cart"] = cart;

            lblMsg.Text = "Product added to cart!";
        }
    }