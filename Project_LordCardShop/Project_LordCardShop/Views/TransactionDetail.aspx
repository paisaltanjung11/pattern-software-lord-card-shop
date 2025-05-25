<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="Project_LordCardShop.Views.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Transaction Detail</h3>
    <hr />

    <div class="card mb-4">
        <div class="card-body">
            <p><strong>Transaction ID:</strong> <asp:Label ID="lblTransactionId" runat="server"></asp:Label></p>
            <p><strong>Date:</strong> <asp:Label ID="lblDate" runat="server"></asp:Label></p>
            <p><strong>Customer:</strong> <asp:Label ID="lblCustomer" runat="server"></asp:Label></p>
            <p><strong>Status:</strong> <asp:Label ID="lblStatus" runat="server"></asp:Label></p>
        </div>
    </div>
    
    <h4>Items in this Transaction:</h4>
    <asp:GridView ID="DetailGridView" runat="server" AutoGenerateColumns="False" 
        CssClass="table" GridLines="None" ShowFooter="True" OnRowDataBound="DetailGridView_RowDataBound">
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
    
    <a href="TransactionHistory.aspx" class="btn btn-secondary mt-3">Back to History</a>
</asp:Content>
