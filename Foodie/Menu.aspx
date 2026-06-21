<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Foodie.Menu" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<div class="p-4 mb-4 rounded text-white text-center" style="background:#c0392b;">
  <h2 class="fw-bold">Our Menu</h2>
  <p class="mb-0">Fresh food, made with love</p>
</div>

<div class="row mb-4">
  <div class="col-md-5 mb-2">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search food items..." />
  </div>
  <div class="col-md-4 mb-2">
    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select">
      <asp:ListItem Value="">All Categories</asp:ListItem>
      <asp:ListItem Value="Burgers">Burgers</asp:ListItem>
      <asp:ListItem Value="Pizza">Pizza</asp:ListItem>
      <asp:ListItem Value="Sides">Sides</asp:ListItem>
      <asp:ListItem Value="Drinks">Drinks</asp:ListItem>
    </asp:DropDownList>
  </div>
  <div class="col-md-3 mb-2">
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn w-100 text-white" style="background:#c0392b;" OnClick="btnSearch_Click" />
  </div>
</div>

<div class="row" id="menuGrid" runat="server"></div>

</asp:Content>