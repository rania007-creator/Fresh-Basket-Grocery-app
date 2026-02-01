using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


    public partial class Admin_AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
           {
            Response.Redirect("Login.aspx");
           }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (fuImage.HasFile)
            {
                string fileName = Path.GetFileName(fuImage.FileName);
                string folderPath = Server.MapPath("~/Images/");
                string imagePath = "Images/" + fileName;

                // Save image to Images folder
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                fuImage.SaveAs(folderPath + fileName);

                // Insert product into database
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Products 
                        (Name, Price, Category, Description, ImagePath)
                        VALUES (@name, @price, @category, @desc, @img)", con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@img", imagePath);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMessage.Text = "Product added successfully!";
                ClearFields();
            }
            else
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please upload an image.";
            }
        }

        private void ClearFields()
        {
            txtName.Text = txtPrice.Text = txtCategory.Text = txtDescription.Text = "";
        }
    }

