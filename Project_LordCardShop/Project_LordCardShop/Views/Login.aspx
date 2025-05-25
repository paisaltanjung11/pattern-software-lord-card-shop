<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project_LordCardShop.Views.Login" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <h2>Login</h2>
            <hr />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtEmail">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group form-check">
                <%-- Menggunakan asp:CheckBox dengan Label yang terasosiasi dengan benar --%>
                <asp:CheckBox ID="chkRememberMe" runat="server" Text=" Remember Me" CssClass="form-check-input" />
                <label class="form-check-label" for="<%= chkRememberMe.ClientID %>"></label>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
            <br />
            <asp:Label ID="lblError" runat="server" CssClass="text-danger mt-2"></asp:Label>
        </div>
    </div>
</asp:Content>