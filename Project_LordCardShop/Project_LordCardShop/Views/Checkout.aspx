<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Project_LordCardShop.Views.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Checkout Confirmation</h2>
    <p>Please review your order one last time before confirming.</p>
    <hr />

    <%-- Kita gunakan lagi GridView yang sama persis seperti di Cart untuk menampilkan ringkasan --%>
    <asp:GridView ID="CheckoutGridView" runat="server" AutoGenerateColumns="False" 
        CssClass="table" GridLines="None" ShowFooter="True" OnRowDataBound="CheckoutGridView_RowDataBound">
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
    
    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
    <br />
    <asp:Button ID="btnConfirmCheckout" runat="server" Text="Confirm Checkout" CssClass="btn btn-success" OnClick="btnConfirmCheckout_Click" />
    <a href="Cart.aspx" class="btn btn-secondary">Back to Cart</a>
</asp:Content>
