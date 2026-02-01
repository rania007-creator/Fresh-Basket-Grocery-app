using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

    public partial class Views_CheckOut : System.Web.UI.Page
    {
        DataTable cartTable = new DataTable();
        decimal total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                LoadCartSummary();
            }
        }

        private void LoadCartSummary()
        {
            List<int> cart = Session["Cart"] as List<int>;
            if (cart == null || cart.Count == 0)
            {
                lblTotal.Text = "Your cart is empty.";
                btnPlaceOrder.Enabled = false;
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string ids = string.Join(",", cart.Select(i => i.ToString()).Distinct());
                SqlCommand cmd = new SqlCommand("SELECT ProductID, Name, Price FROM Products WHERE ProductID IN (" + ids + ")", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(cartTable);

                gvSummary.DataSource = cartTable;
                gvSummary.DataBind();

                total = cartTable.AsEnumerable().Sum(row => row.Field<decimal>("Price"));
                lblTotal.Text = "Total Amount: Rs " + total.ToString("N2");

                ViewState["CartTable"] = cartTable;
                ViewState["TotalAmount"] = total;
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            cartTable = ViewState["CartTable"] as DataTable;
            total = Convert.ToDecimal(ViewState["TotalAmount"]);

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, Status) VALUES (@custId, GETDATE(), @total, 'Pending'); SELECT SCOPE_IDENTITY();", con, trans);
                    cmd.Parameters.AddWithValue("@custId", userId);
                    cmd.Parameters.AddWithValue("@total", total);
                    int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (DataRow row in cartTable.Rows)
                    {
                        SqlCommand detailCmd = new SqlCommand("INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price) VALUES (@oid, @pid, @qty, @price)", con, trans);
                        detailCmd.Parameters.AddWithValue("@oid", orderId);
                        detailCmd.Parameters.AddWithValue("@pid", row["ProductID"]);
                        detailCmd.Parameters.AddWithValue("@qty", 1); // Default quantity 1 (can enhance)
                        detailCmd.Parameters.AddWithValue("@price", row["Price"]);
                        detailCmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    lblMessage.Text = "Order placed successfully!";
                    Session["Cart"] = null;
                    gvSummary.DataSource = null;
                    gvSummary.DataBind();
                    lblTotal.Text = "";
                    btnPlaceOrder.Enabled = false;
                }
                catch
                {
                    trans.Rollback();
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "Order failed. Please try again.";
                }
            }
        }
    }