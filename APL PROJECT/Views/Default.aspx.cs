using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

    public partial class Views_Default : System.Web.UI.Page
    {
    protected void btnShop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx");
            
        }

      
    }