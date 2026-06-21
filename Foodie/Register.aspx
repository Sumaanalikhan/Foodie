<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Foodie.Register" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div class="row justify-content-center">
  <div class="col-md-5">
    <div class="card shadow-sm border-0 p-4 mt-3">
      <h3 class="mb-4 text-center" style="color:#c0392b;">Create Account</h3>
      <asp:Label ID="lblMsg" runat="server" CssClass="text-danger d-block mb-2" />
      <div class="mb-3">
        <label class="form-label">Full Name</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Your full name" />
      </div>
      <div class="mb-3">
        <label class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="you@email.com" />
      </div>
      <div class="mb-3">
        <label class="form-label">Password</label>
        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" />
      </div>
      <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn w-100 text-white" style="background:#c0392b;" OnClick="btnRegister_Click" />
      <p class="text-center mt-3">Already have an account? <a href="Login.aspx">Login</a></p>
    </div>
  </div>
</div>
</asp:Content>