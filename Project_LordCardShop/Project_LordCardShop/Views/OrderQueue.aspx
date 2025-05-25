<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="Project_LordCardShop.Views.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Order Queue Management</h2>
    <p>Manage incoming customer orders from this page.</p>
    <hr />
    
    <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>

    <h4><i class="fas fa-inbox"></i> Unhandled Orders</h4>
    <p>These orders are waiting to be processed.</p>
    <asp:GridView ID="UnhandledGridView" runat="server" AutoGenerateColumns="False" 
        CssClass="table table-hover table-bordered" GridLines="None" OnRowCommand="UnhandledGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:D}" />
            <asp:TemplateField HeaderText="Customer">
                <ItemTemplate>
                    <%# Eval("User.UserName") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnHandle" runat="server" Text="Handle Transaction" CssClass="btn btn-primary btn-sm" 
                        CommandName="Handle" CommandArgument='<%# Eval("TransactionID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div class="alert alert-info">No unhandled orders at the moment.</div>
        </EmptyDataTemplate>
    </asp:GridView>

    <hr class="my-5" />

    <h4><i class="fas fa-check-circle"></i> Handled Orders</h4>
    <p>These orders have been successfully processed.</p>
    <asp:GridView ID="HandledGridView" runat="server" AutoGenerateColumns="False" 
        CssClass="table table-hover" GridLines="None">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:D}" />
            <asp:TemplateField HeaderText="Customer">
                <ItemTemplate>
                    <%# Eval("User.UserName") %>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="Status" HeaderText="Status" />
        </Columns>
         <EmptyDataTemplate>
            <div class="alert alert-secondary">No handled orders found.</div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
