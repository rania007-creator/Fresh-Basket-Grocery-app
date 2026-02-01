using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class Views_MyOrders : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["Role"].ToString() != "Customer")
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                LoadMyOrders();
            }
        }

        private void LoadMyOrders()
        {
            int userId = Convert.ToInt32(Session["UserID"]);

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.Status, p.Name FROM Orders o INNER JOIN OrderDetails od ON o.OrderID = od.OrderID INNER JOIN Products p ON od.ProductID = p.ProductID WHERE o.CustomerID = @custId ORDER BY o.OrderDate DESC;", con);
                cmd.Parameters.AddWithValue("@custId", userId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gvOrders.DataSource = dt;
                gvOrders.DataBind();
            }
        }

        protected void gvOrders_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvOrders.Rows[index];
                int orderId = Convert.ToInt32(gvOrders.DataKeys[index].Value);

                LoadOrderDetails(orderId);
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            pnlDetails.Visible = true;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT p.Name AS ProductName, od.Quantity, od.Price
                    FROM OrderDetails od
                    JOIN Products p ON od.ProductID = p.ProductID
                    WHERE od.OrderID = @oid", con);
                cmd.Parameters.AddWithValue("@oid", orderId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gvDetails.DataSource = dt;
                gvDetails.DataBind();
            }
        }
    }