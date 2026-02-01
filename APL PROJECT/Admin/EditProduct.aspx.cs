using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

    public partial class Admin_EditProduct : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int productId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                if (Request.QueryString["ProductID"] != null)
                {
                    productId = Convert.ToInt32(Request.QueryString["ProductID"]);
                    LoadProductDetails(productId);
                }
                else
                {
                    Response.Redirect("ManageProducts.aspx");
                }
            }
        }

        private void LoadProductDetails(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr["Name"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtCategory.Text = dr["Category"].ToString();
                    txtDescription.Text = dr["Description"].ToString();
                    imgProduct.ImageUrl = "~/" + dr["ImagePath"].ToString();
                    ViewState["ImagePath"] = dr["ImagePath"].ToString();
                }
                con.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            productId = Convert.ToInt32(Request.QueryString["ProductID"]);
            string imagePath = ViewState["ImagePath"].ToString();

            if (fuImage.HasFile)
            {
                string fileName = Path.GetFileName(fuImage.FileName);
                string folderPath = Server.MapPath("~/Images/");
                fuImage.SaveAs(folderPath + fileName);
                imagePath = "Images/" + fileName;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Products SET 
                      Name = @name,
                      Price = @price,
                      Category = @cat,
                      Description = @desc,
                      ImagePath = @img
                      WHERE ProductID = @id", con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@img", imagePath);
                cmd.Parameters.AddWithValue("@id", productId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Product updated successfully!";
        }
    }