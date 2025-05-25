using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_LordCardShop.Handlers;
using Project_LordCardShop.Models;
using Project_LordCardShop.Repositories;

namespace Project_LordCardShop.Views
{
    public partial class Cart : System.Web.UI.Page
    {
        private decimal grandTotal = 0; // Gunakan decimal untuk uang agar lebih presisi

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((User)Session["user"]).UserRole != "Customer")
            {
                Response.Redirect("~/Views/Login.aspx"); // Path yang konsisten
                return;
            }

            if (!IsPostBack)
            {
                BindCartData();
            }
        }

        private void BindCartData()
        {
            User currentUser = (User)Session["user"];
            // Pastikan method ini sekarang mengembalikan Cart beserta detail Card-nya
            List<Cart> cartItems = CartRepository.GetCartsByUserId(currentUser.UserID);

            if (cartItems == null || cartItems.Count == 0)
            {
                lblEmptyCart.Visible = true;
                CartGridView.Visible = false;
                divActions.Visible = false; // Sembunyikan tombol jika keranjang kosong
            }
            else
            {
                lblEmptyCart.Visible = false;
                CartGridView.Visible = true;
                divActions.Visible = true;
                CartGridView.DataSource = cartItems;
                CartGridView.DataBind();
            }
        }

        protected void CartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Ambil data dari baris saat ini
                Cart cartItem = (Cart)e.Row.DataItem;

                // Cek apakah objek Card benar-benar ada untuk menghindari error
                if (cartItem.Card != null)
                {
                    decimal price = cartItem.Card.CardPrice; // Gunakan decimal
                    int quantity = cartItem.Quantity;
                    decimal subTotal = price * quantity;

                    grandTotal += subTotal; // Tambahkan sub-total ke grand total

                    // Temukan label sub-total dan isi nilainya
                    Label lblSubTotal = (Label)e.Row.FindControl("lblSubTotal");
                    if (lblSubTotal != null)
                    {
                        lblSubTotal.Text = subTotal.ToString("N0"); // Format tanpa "Rp" agar bisa dijumlahkan
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                // Tampilkan grand total di footer
                // e.Row.Cells[0].Text = "Grand Total";
                // e.Row.Cells[0].ColumnSpan = 3;
                // e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].Text = grandTotal.ToString("N0"); // Tampilkan grand total di kolom sub-total
                e.Row.Cells[3].Font.Bold = true;

                // Hapus sel yang tidak perlu di footer
                // e.Row.Cells[1].Visible = false;
                // e.Row.Cells[2].Visible = false;
            }
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            User currentUser = (User)Session["user"];
            CartHandler.ClearCart(currentUser.UserID);
            BindCartData(); // Muat ulang data untuk menampilkan keranjang yang sudah kosong
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            // Redirect ke halaman Checkout
            Response.Redirect("~/Views/Checkout.aspx");
        }
    }
}