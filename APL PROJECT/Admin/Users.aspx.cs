using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
        {
        if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                LoadCustomers();
            }
        }

        private void LoadCustomers()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT UserID, FullName, Email, PhoneNumber, Address, City FROM Users WHERE Role='Customer'", con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }
    }