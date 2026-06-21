<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Foodie.Cart" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<h3 class="mb-4" style="color:#c0392b;"><i class="fas fa-shopping-cart me-2"></i>Your Cart</h3>
<asp:PlaceHolder ID="phCart" runat="server" />
</asp:Content>