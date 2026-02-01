using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvProducts.DataSource = dt;
            gvProducts.DataBind();
        }
    }

    protected void gvProducts_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int productId = Convert.ToInt32(gvProducts.DataKeys[index].Value);

        if (e.CommandName == "EditProduct")
        {
            Response.Redirect("EditProduct.aspx?ProductID=" + productId);
        }
        else if (e.CommandName == "DeleteProduct")
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @id", con);
                cmd.Parameters.AddWithValue("@id", productId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            BindGrid();
            lblMessage.Text = "Product deleted successfully.";
        }
    }
}