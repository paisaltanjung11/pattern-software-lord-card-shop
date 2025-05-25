using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_LordCardShop.Handlers;
using Project_LordCardShop.Models;
using Project_LordCardShop.Repositories;

namespace Project_LordCardShop.Views
{
    public partial class Checkout : System.Web.UI.Page
    {
        private double grandTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((User)Session["user"]).UserRole != "Customer")
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                BindCheckoutSummary();
            }
        }
        private void BindCheckoutSummary()
        {
            User currentUser = (User)Session["user"];
            List<Cart> cartItems = CartRepository.GetCartsByUserId(currentUser.UserID);

            if (cartItems.Count == 0)
            {
                // jika user somehow sampai sini dengan keranjang kosong, tendang balik
                Response.Redirect("Cart.aspx");
            }

            CheckoutGridView.DataSource = cartItems;
            CheckoutGridView.DataBind();
        }
        protected void CheckoutGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Cart cartItem = (Cart)e.Row.DataItem;
                double price = cartItem.Card.CardPrice;
                int quantity = cartItem.Quantity;
                double subTotal = price * quantity;
                grandTotal += subTotal;
                Label lblSubTotal = (Label)e.Row.FindControl("lblSubTotal");
                lblSubTotal.Text = "Rp " + subTotal.ToString("N0");
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "Rp " + grandTotal.ToString("N0");
            }
        }
        protected void btnConfirmCheckout_Click(object sender, EventArgs e)
        {
            User currentUser = (User)Session["user"];
            string result = TransactionHandler.Checkout(currentUser.UserID);

            if (result == "success")
            {
                // jika checkout berhasil, arahkan ke riwayat transaksi
                Response.Redirect("TransactionHistory.aspx");
            }
            else
            {
                // tampilkan error jika ada masalah
                lblMessage.Text = result;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}