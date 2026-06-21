<%@ Page Title="Admin Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Foodie.AdminLogin" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div class="row justify-content-center">
  <div class="col-md-4">
    <div class="card border-0 shadow-sm p-4 mt-3">
      <h3 class="text-center mb-4" style="color:#c0392b;">Admin Login</h3>
      <asp:Label ID="lblMsg" runat="server" CssClass="text-danger d-block mb-2" />
      <div class="mb-3">
        <label class="form-label">Username</label>
        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" />
      </div>
      <div class="mb-3">
        <label class="form-label">Password</label>
        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" />
      </div>
      <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn w-100 text-white" style="background:#c0392b;" OnClick="btnLogin_Click" />
    </div>
  </div>
</div>
</asp:Content>