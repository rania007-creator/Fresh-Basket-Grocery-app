<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/Assets/Bootstrap/css/bootstrap.min.css" />

    <title></title>
</head>
<body class="bg-success">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center text-danger mb-4">Customer Sign Up</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>

            <div class="mb-3 fs-4">
                <label>Full Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Required="true" />
            </div>

            <div class="mb-3 fs-4">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Required="true" />
            </div>

            <div class="mb-3 fs-4">
                <label>Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Required="true" />
            </div>

            <div class="mb-3 fs-4">
                <label>Phone Number</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Phone" Required="true" />
            </div>

            <div class="mb-3 fs-4">
                <label>Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Required="true" />
            </div>

                <div class="mb-3 fs-4">
                <label>City</label>
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn btn-danger btn-block" OnClick="btnSignUp_Click" ForeColor="White" />
        </div>
    </form>
</body>
</html>
