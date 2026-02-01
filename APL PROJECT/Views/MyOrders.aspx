<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CustomerMaster.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="Views_MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2>My Orders</h2>

    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvOrders_RowCommand">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
            <asp:BoundField DataField="Name" HeaderText="Product Name" />
            <asp:BoundField DataField="OrderDate" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount (Rs)" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:ButtonField CommandName="ViewDetails" Text="View Details" ButtonType="Button" />
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlDetails" runat="server" Visible="false" CssClass="mt-4">
        <h4>Order Details</h4>
        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" />
                <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                <asp:BoundField DataField="Price" HeaderText="Price (Rs)" DataFormatString="{0:N2}" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>


