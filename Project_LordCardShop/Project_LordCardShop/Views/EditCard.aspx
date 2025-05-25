<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="EditCard.aspx.cs" Inherits="Project_LordCardShop.Views.EditCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Edit Card</h2>
    <p>Update the card's information below.</p>
    <hr />
    
    <div class="row justify-content-center">
        <div class="col-md-8">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtName">Card Name</asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtPrice">Price</asp:Label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtDescription">Description</asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddlType">Type</asp:Label>
                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                    <asp:ListItem Text="-- Select Type --" Value=""></asp:ListItem>
                    <asp:ListItem>Spell</asp:ListItem>
                    <asp:ListItem>Monster</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddlFoil">Is Foil?</asp:Label>
                <asp:DropDownList ID="ddlFoil" runat="server" CssClass="form-control">
                    <asp:ListItem Text="-- Select Option --" Value=""></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <asp:Button ID="btnUpdate" runat="server" Text="Update Card" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
            <a href="ManageCard.aspx" class="btn btn-secondary">Back to Manage</a>
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="mt-2" EnableViewState="false"></asp:Label>
        </div>
    </div>
</asp:Content>
