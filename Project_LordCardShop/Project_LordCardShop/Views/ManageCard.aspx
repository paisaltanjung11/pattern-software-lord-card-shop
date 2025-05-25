<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="Project_LordCardShop.Views.ManageCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Cards</h2>
    <p>Here you can add, update, or delete cards from the database.</p>
    
    <asp:Button ID="btnInsert" runat="server" Text="Insert New Card" CssClass="btn btn-success mb-3" OnClick="btnInsert_Click" />
    <hr />

    <asp:GridView ID="CardGridView" runat="server" AutoGenerateColumns="False" 
        CssClass="table table-hover table-bordered" GridLines="None"
        DataKeyNames="CardID" OnRowCommand="CardGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="CardID" HeaderText="ID" />
            <asp:BoundField DataField="CardName" HeaderText="Name" />
            <asp:BoundField DataField="CardPrice" HeaderText="Price" DataFormatString="{0:N0}" />
            <asp:BoundField DataField="CardDesc" HeaderText="Description" />
            <asp:BoundField DataField="CardType" HeaderText="Type" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary btn-sm" 
                        CommandName="UpdateCard" CommandArgument='<%# Eval("CardID") %>' />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" 
                        CommandName="DeleteCard" CommandArgument='<%# Eval("CardID") %>' OnClientClick="return confirm('Are you sure you want to delete this card?');"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
