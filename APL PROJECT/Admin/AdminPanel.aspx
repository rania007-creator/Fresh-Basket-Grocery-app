<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminPanel.aspx.cs" Inherits="Admin_AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2 style="margin-top:100px;">Welcome, Admin</h2>
    <div class="row">
        <div class="col-md-3">
            <div class="card text-white bg-primary mb-3">
                <div class="card-body">
                    <h5 class="card-title">Total Products</h5>
                    <p class="card-text"><asp:Label ID="lblProducts" runat="server" /></p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-success mb-3">
                <div class="card-body">
                    <h5 class="card-title">Total Customers</h5>
                    <p class="card-text"><asp:Label ID="lblCustomers" runat="server" /></p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-warning mb-3">
                <div class="card-body">
                    <h5 class="card-title">Total Orders</h5>
                    <p class="card-text"><asp:Label ID="lblOrders" runat="server" /></p>
                </div>
            </div>
        </div>
    </div>
    <div style="height: 170px;"></div>
</asp:Content>


