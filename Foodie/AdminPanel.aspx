<%@ Page Title="Admin Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Foodie.AdminPanel" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<h3 style="color:#c0392b;" class="mb-4"><i class="fas fa-cogs me-2"></i>Admin Panel — Menu Management</h3>

<div class="card border-0 shadow-sm p-4 mb-4">
  <h5>Add New Item</h5>
  <asp:Label ID="lblMsg" runat="server" CssClass="text-success d-block mb-2" />
  <div class="row g-2">
    <div class="col-md-3"><asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Item name" /></div>
    <div class="col-md-3"><asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" placeholder="Description" /></div>
    <div class="col-md-2"><asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Price" /></div>
    <div class="col-md-2">
      <asp:DropDownList ID="ddlCat" runat="server" CssClass="form-select">
        <asp:ListItem>Burgers</asp:ListItem>
        <asp:ListItem>Pizza</asp:ListItem>
        <asp:ListItem>Sides</asp:ListItem>
        <asp:ListItem>Drinks</asp:ListItem>
      </asp:DropDownList>
    </div>
    <div class="col-md-2"><asp:TextBox ID="txtImg" runat="server" CssClass="form-control" placeholder="image.jpg" /></div>
  </div>
  <asp:Button ID="btnAdd" runat="server" Text="Add Item" CssClass="btn text-white mt-3" style="background:#c0392b;" OnClick="btnAdd_Click" />
</div>

<h5>Current Menu Items</h5>
<asp:GridView ID="gvItems" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false"
    OnRowCommand="gvItems_RowCommand" DataKeyNames="ItemID">
  <Columns>
    <asp:BoundField DataField="ItemID" HeaderText="ID" />
    <asp:BoundField DataField="Name" HeaderText="Name" />
    <asp:BoundField DataField="Category" HeaderText="Category" />
    <asp:BoundField DataField="Price" HeaderText="Price (Rs.)" />
    <asp:TemplateField HeaderText="Action">
      <ItemTemplate>
        <asp:LinkButton CommandName="DeleteItem" CommandArgument='<%# Eval("ItemID") %>'
            runat="server" CssClass="btn btn-sm btn-danger"
            OnClientClick="return confirm('Delete this item?');">Delete</asp:LinkButton>
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
</asp:GridView>
</asp:Content>