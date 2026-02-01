<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AllOrders.aspx.cs" Inherits="Admin_AllOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2>All Orders</h2>
     <!-- Optional: Add status update functionality later -->
    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
            <asp:BoundField DataField="FullName" HeaderText="Customer" />
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:dd-MM-yyyy}" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />

           
        </Columns>
    </asp:GridView>
</asp:Content>


