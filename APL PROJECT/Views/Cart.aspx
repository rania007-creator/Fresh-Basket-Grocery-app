<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CustomerMaster.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Views_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2 style="margin-top:70px;">Shopping Cart</h2>

    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvCart_RowCommand">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Product Name" />
            <asp:BoundField DataField="Price" HeaderText="Price (Rs)" DataFormatString="{0:N2}" />

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQty" runat="server" Width="50px" Text="1" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("ProductID") %>' CssClass="btn btn-danger btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />
    <br /><br />
    <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" CssClass="btn btn-success" OnClick="btnCheckout_Click" />
    <div style="height:150px;"></div>
</asp:Content>


