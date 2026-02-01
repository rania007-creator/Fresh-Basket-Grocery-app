using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            CountStats();
        }
    }

    private void CountStats()
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();

            // Count Products
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Products", con);
            lblProducts.Text = cmd.ExecuteScalar().ToString();

            // Count Customers
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Role='Customer'";
            lblCustomers.Text = cmd.ExecuteScalar().ToString();

            // Count Orders
            cmd.CommandText = "SELECT COUNT(*) FROM Orders";
            lblOrders.Text = cmd.ExecuteScalar().ToString();
        }
    }
}