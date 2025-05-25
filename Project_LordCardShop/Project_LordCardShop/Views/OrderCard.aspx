<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="Project_LordCardShop.Views.OrderCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Our Collection</h2>
    <p>Find your favorite cards and add them to your cart!</p>
    <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info"></asp:Label>
    <hr />

    <div class="row">
        <asp:Repeater ID="CardRepeater" runat="server" OnItemCommand="CardRepeater_ItemCommand">
            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("CardName") %></h5>
                            <h6 class="card-subtitle mb-2 text-muted">Rp <%# Eval("CardPrice", "{0:N0}") %></h6>
                            <p class="card-text"><%# Eval("CardDesc") %></p>
                            
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" Text="1"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-primary" 
                                        CommandName="AddToCart" CommandArgument='<%# Eval("CardID") %>' />
                                </div>
                            </div>
                            <asp:HyperLink ID="hlDetail" runat="server" CssClass="btn btn-secondary btn-block" Text="View Detail" 
                                NavigateUrl='<%# "~/Views/CardDetail.aspx?id=" + Eval("CardID") %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
