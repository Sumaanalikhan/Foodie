<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Foodie.Login" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div class="row justify-content-center">
  <div class="col-md-5">
    <div class="card shadow-sm border-0 p-4 mt-3">
      <h3 class="mb-4 text-center" style="color:#c0392b;">Login</h3>
      <asp:Label ID="lblMsg" runat="server" CssClass="text-danger d-block mb-2" />
      <div class="mb-3">
        <label class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
      </div>
      <div class="mb-3">
        <label class="form-label">Password</label>
        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" />
      </div>
      <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn w-100 text-white" style="background:#c0392b;" OnClick="btnLogin_Click" />
      <p class="text-center mt-3">No account? <a href="Register.aspx">Register</a></p>
    </div>
  </div>
</div>
</asp:Content>