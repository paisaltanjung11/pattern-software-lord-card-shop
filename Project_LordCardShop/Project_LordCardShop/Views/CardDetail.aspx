<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="CardDetail.aspx.cs" Inherits="Project_LordCardShop.Views.CardDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8 offset-md-2">
            <div class="card">
                <div class="card-header">
                    <h3><asp:Label ID="lblName" runat="server" Text="Card Name"></asp:Label></h3>
                </div>
                <div class="card-body">
                    <p><strong>Price:</strong> <asp:Label ID="lblPrice" runat="server" Text="Rp 0"></asp:Label></p>
                    <p><strong>Type:</strong> <asp:Label ID="lblType" runat="server" Text="-"></asp:Label></p>
                    <p><strong>Foil:</strong> <asp:Label ID="lblFoil" runat="server" Text="-"></asp:Label></p>
                    <hr />
                    <p><strong>Description:</strong></p>
                    <p><asp:Label ID="lblDesc" runat="server" Text="Description will be here."></asp:Label></p>
                </div>
                <div class="card-footer">
                    <a href="OrderCard.aspx" class="btn btn-secondary">Back to Order Page</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
