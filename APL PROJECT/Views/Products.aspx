<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CustomerMaster.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Views_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2>All Products</h2>

    <div class="row">
        <asp:Repeater ID="rptAllProducts" runat="server">
            <ItemTemplate>
                <div class="col-md-3 mb-3">
                    <div class="card h-100">
                        <img src='<%# ResolveUrl("~/" + Eval("ImagePath")) %>' class="card-img-top" style="height:180px;" />
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Name") %></h5>
                            <h5 class="card-text"><%# Eval("Description") %></h5>
                            <p class="card-text">Rs <%# Eval("Price") %></p>
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart"
                                CssClass="btn btn-primary btn-sm"
                                CommandArgument='<%# Eval("ProductID") %>'
                                OnCommand="btnAddToCart_Command" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:Label ID="lblMsg" runat="server" CssClass="text-success mt-2" />
</asp:Content>


