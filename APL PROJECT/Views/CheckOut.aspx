<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CustomerMaster.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="Views_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2>Order Summary</h2>

    <asp:GridView ID="gvSummary" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Product Name" />
            <asp:BoundField DataField="Price" HeaderText="Price (Rs)" DataFormatString="{0:N2}" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblTotal" runat="server" Font-Bold="true" CssClass="d-block mt-2" />
    <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" CssClass="btn btn-success mt-3" OnClick="btnPlaceOrder_Click" />
    <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-block mt-2" />
</asp:Content>


