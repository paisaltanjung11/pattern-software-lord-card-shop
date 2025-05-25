<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Project_LordCardShop.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Update Your Profile</h2>
    <p>You can update your personal information here.</p>
    <hr />

    <div class="row justify-content-center">
        <div class="col-md-8">
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
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtDob">Date of Birth</asp:Label>
                <asp:TextBox ID="txtDob" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <hr />
            <h4>Change Password</h4>
            <p><small class="text-muted">(Leave these fields blank if you do not want to change your password)</small></p>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtOldPassword">Old Password</asp:Label>
                <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtNewPassword">New Password</asp:Label>
                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtConfirmPassword">Confirm New Password</asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="mt-2" EnableViewState="false"></asp:Label>
        </div>
    </div>
</asp:Content>
