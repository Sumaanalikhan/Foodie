<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Foodie.Checkout" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div class="row justify-content-center">
  <div class="col-md-6">
    <div class="card border-0 shadow-sm p-4">
      <h3 style="color:#c0392b;" class="mb-3">Order Summary</h3>
      <asp:PlaceHolder ID="phSummary" runat="server" />
      <asp:Label ID="lblMsg" runat="server" CssClass="fw-bold d-block mt-3" />
      <asp:Button ID="btnPlace" runat="server" Text="Place Order" CssClass="btn w-100 text-white mt-3" style="background:#c0392b;" OnClick="btnPlace_Click" />
    </div>
  </div>
</div>
</asp:Content>