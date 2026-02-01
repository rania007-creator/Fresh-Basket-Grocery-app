using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

    public partial class Admin_AllOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT o.OrderID, u.FullName, o.OrderDate, o.TotalAmount, o.Status
                    FROM Orders o
                    JOIN Users u ON o.CustomerID = u.UserID
                    ORDER BY o.OrderDate DESC", con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gvOrders.DataSource = dt;
                gvOrders.DataBind();
            }
        }
    }