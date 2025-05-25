<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Project_LordCardShop.Views.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your Shopping Cart</h2>
    <hr />

    <asp:Label ID="lblEmptyCart" runat="server" Text="Your cart is empty." CssClass="alert alert-warning" Visible="false"></asp:Label>

    <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" 
        CssClass="table table-hover" GridLines="None" ShowFooter="True" OnRowDataBound="CartGridView_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Card.CardName" HeaderText="Card Name" />
            <asp:BoundField DataField="Card.CardPrice" HeaderText="Price" DataFormatString="{0:N0}" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:TemplateField HeaderText="Sub-Total">
                <ItemTemplate>
                    <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                </ItemTemplate>
                <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                <FooterTemplate>
                    Grand Total:
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <div id="divActions" runat="server">
        <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" CssClass="btn btn-danger" OnClick="btnClearCart_Click" />
        <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" CssClass="btn btn-success" OnClick="btnCheckout_Click" />
    </div>
</asp:Content>
