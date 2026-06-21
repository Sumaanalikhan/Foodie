<%@ Page Title="My Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="Foodie.OrderHistory" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<h3 style="color:#c0392b;" class="mb-4"><i class="fas fa-list me-2"></i>My Orders</h3>
<asp:PlaceHolder ID="phOrders" runat="server" />
</asp:Content>