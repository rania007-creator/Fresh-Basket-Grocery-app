<%@ Page Title="Edit Product" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="Admin_EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Product</h2>

    <asp:ValidationSummary runat="server" CssClass="text-danger" />

    <div class="form-group">
        <label>Product Name:</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Price:</label>
        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number" />
    </div>

    <div class="form-group">
        <label>Category:</label>
        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Description:</label>
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>

    <div class="form-group">
        <label>Current Image:</label><br />
        <asp:Image ID="imgProduct" runat="server" Width="100" />
    </div>

    <div class="form-group">
        <label>Change Image (optional):</label>
        <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file" />
    </div>

    <asp:Button ID="btnUpdate" runat="server" Text="Update Product" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
    <asp:Label ID="lblMessage" runat="server" CssClass="text-success" />

</asp:Content>
