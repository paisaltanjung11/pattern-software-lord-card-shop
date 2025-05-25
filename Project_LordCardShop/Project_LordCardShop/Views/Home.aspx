<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project_LordCardShop.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1 class="display-4">Welcome to LOrd Card Shop!</h1>
        <p class="lead">
            <asp:Label ID="lblWelcomeMessage" runat="server" Text="Hello, Guest!"></asp:Label>
        </p>
        <hr class="my-4" />
        <p>Your one-stop solution for buying and selling collectible cards.</p>
    </div>
</asp:Content>
