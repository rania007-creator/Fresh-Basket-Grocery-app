<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CustomerMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Views_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <section class="banner"  id="home">
      <img src="../Assets/Image/banner-img.jpg" alt="Banner Image" />
      <div class="content">
        <h3>Welcome to <span>Our Grocery Store</span></h3>
        <p>The supermarket typically comprises meat, fresh produce, dairy, and baked goods aisles, along with shelf space reserved for canned and packaged goods and non-food items.</p>
          <asp:Button ID="btnShop" runat="server" Text="Shop Now" CssClass="btn btn-primary btn-lg" OnClick="btnShop_Click" />
      </div>
    </section>

    <section id="Features" class="py-5 bg-white">
  <div class="container">
    <h2 class="text-center mb-5">Why Shop With Us?</h2>
    <div class="row text-center">
      <div class="col-md-4 mb-4">
        <div class="p-4 shadow-sm border rounded">
          <i class="bi bi-truck display-4 text-primary mb-3"></i>
          <h5>Fast Delivery</h5>
          <p>Get your groceries delivered to your doorstep in no time.</p>
        </div>
      </div>
      <div class="col-md-4 mb-4">
        <div class="p-4 shadow-sm border rounded">
          <i class="bi bi-bag-check display-4 text-success mb-3"></i>
          <h5>Quality Products</h5>
          <p>We ensure only the freshest and highest quality items for you.</p>
        </div>
      </div>
      <div class="col-md-4 mb-4">
        <div class="p-4 shadow-sm border rounded">
          <i class="bi bi-shield-check display-4 text-warning mb-3"></i>
          <h5>Secure Shopping</h5>
          <p>Your personal data and transactions are always safe with us.</p>
        </div>
      </div>
    </div>
  </div>
</section>

    <!-- Reviews Section -->
<section id="Reviews" class="bg-light py-5">
  <div class="container">
    <h2 class="text-center mb-4">Customer Reviews</h2>
    <div class="row">
      <div class="col-md-4 mb-4">
        <div class="card h-100 shadow-sm">
          <div class="card-body">
            <h5 class="card-title">Ayesha R.</h5>
            <p class="card-text">“I love this store! The fruits and vegetables are always fresh and delivered quickly.”</p>
            <div class="text-warning">
              ★★★★☆
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-4 mb-4">
        <div class="card h-100 shadow-sm">
          <div class="card-body">
            <h5 class="card-title">Ali Khan</h5>
            <p class="card-text">“Great quality meat and dairy products. The dairy section is especially amazing!”</p>
            <div class="text-warning">
              ★★★★★
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-4 mb-4">
        <div class="card h-100 shadow-sm">
          <div class="card-body">
            <h5 class="card-title">Zainab M.</h5>
            <p class="card-text">“Easy to use website and I love the cart feature. Highly recommended!”</p>
            <div class="text-warning">
              ★★★★☆
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</asp:Content>


