<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="/Assets/Bootstrap/css/bootstrap.min.css" />
</head>
<body class="bg-success">
    <form id="form1" runat="server" >
        <div class="container-fluid ">
            <div class="row" style="height:140px"></div>
            <div class="row ">
                <div class="col-md-2"></div>

                <div class="col-md-4">
                    <img src="Assets/Image/Grocery.jpg" class="img-fluid " style=" width:800px; height:370px;" />
                </div>

                <div class="col-md-4">
                    <h1 class="text-dark">Login</h1>

                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
                  
                    <div class="mb-3">
                        <label>Email address</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter email" />
                    </div>

                    <div class="mb-3">
                        <label>Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" />
                    </div>

                    <div class="mb-3">
                        <asp:RadioButton ID="rbCustomer" runat="server" GroupName="Role" CssClass="form-check-input" />
                        <label class="form-check-label">Customer</label>

                        <asp:RadioButton ID="rbAdmin" runat="server" GroupName="Role" CssClass="form-check-input ms-3" />
                        <label class="form-check-label">Admin</label>
                    </div>

                    <div class="mb-3 d-grid">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success btn-block fs-4" OnClick="btnLogin_Click" />
                    </div>

                    <div class="mb-3 d-flex">
                        Don't Have An Account?  
                        <a href="SignUp.aspx" style="text-decoration:none; color:white">  Sign Up</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
