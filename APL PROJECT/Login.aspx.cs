using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();
        string selectedRole = rbAdmin.Checked ? "Admin" : rbCustomer.Checked ? "Customer" : "";

        if (string.IsNullOrEmpty(email))
        {
            lblMessage.Text = "Please Enter the Email";
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            lblMessage.Text = "Please Enter the Password";
            return;
        }
        if (string.IsNullOrEmpty(selectedRole))
        {
            lblMessage.Text = "Please select a role (Admin or Customer).";
            return;
        }

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = @Email AND Password = @Password AND Role = @Role", con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Role", selectedRole);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                Session["UserID"] = dr["UserID"];
                Session["FullName"] = dr["FullName"];
                Session["Role"] = dr["Role"];

                if (selectedRole == "Admin")
                {
                    Response.Redirect("~/Admin/AdminPanel.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/Default.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid login credentials.";
            }
        }
    }
}
