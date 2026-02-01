<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="Admin_AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2>Add New Product</h2>

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
        <label>Product Image:</label>
        <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file" />
    </div>

    <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
    <asp:Label ID="lblMessage" runat="server" CssClass="text-success" />
</asp:Content>


