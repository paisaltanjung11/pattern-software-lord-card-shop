<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="Project_LordCardShop.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Transaction History</h2>
    <hr />

    <asp:Label ID="lblNoTransactions" runat="server" Text="You have no transaction history." CssClass="alert alert-info" Visible="false"></asp:Label>
    
    <asp:GridView ID="HistoryGridView" runat="server" AutoGenerateColumns="False" 
        CssClass="table table-hover table-bordered" GridLines="None">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:D}" />
            <asp:TemplateField HeaderText="Customer">
                <ItemTemplate>
                    <%# Eval("User.UserName") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField HeaderText="Details">
                <ItemTemplate>
                    <asp:HyperLink ID="hlViewDetail" runat="server" Text="View Detail" CssClass="btn btn-info btn-sm" 
                        NavigateUrl='<%# "~/Views/TransactionDetail.aspx?id=" + Eval("TransactionID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
