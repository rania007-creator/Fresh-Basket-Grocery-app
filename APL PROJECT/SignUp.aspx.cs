using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class SignUp : System.Web.UI.Page
{
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "INSERT INTO Users (FullName, Email, Password, Role, PhoneNumber, Address, City) VALUES (@name, @email, @pass, 'Customer', @phone, @address, @city)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@address", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@city", txtName.Text.Trim());


            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                lblMessage.CssClass = "text-success";
                lblMessage.Text = "Registration successful! ";
                txtName.Text = txtEmail.Text = txtPassword.Text = "";
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                lblMessage.Text = "Registration failed. Try again.";
            }
        }
    }
}

