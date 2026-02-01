<%@ Page Title="Manage Product" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Admin_ManageProducts" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Products</h2>
    <a class="btn btn-success mb-3" href="AddProduct.aspx">+ Add New Product</a>

    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" CssClass="table table-bordered" OnRowCommand="gvProducts_RowCommand">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Description" HeaderText="Description" />

            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <img src='<%# Eval("ImagePath") %>' width="60" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:ButtonField CommandName="EditProduct" Text="Edit" ButtonType="Button" />
            <asp:ButtonField CommandName="DeleteProduct" Text="Delete" ButtonType="Button" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
</asp:Content>



