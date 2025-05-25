<%@ Page Title="Register" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project_LordCardShop.Views.Register" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <%-- Kamu bisa menambahkan CSS atau script khusus untuk halaman ini di sini jika perlu --%>
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <h2>Register an Account</h2>
            <hr />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtUsername">Username</asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtEmail">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server">Gender</asp:Label>
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" CssClass="ml-2">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtDob">Date of Birth</asp:Label>
                <asp:TextBox ID="txtDob" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtConfirmPassword">Confirm Password</asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" CssClass="btn btn-success" />
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="mt-2"></asp:Label>
        </div>
    </div>
</asp:Content>