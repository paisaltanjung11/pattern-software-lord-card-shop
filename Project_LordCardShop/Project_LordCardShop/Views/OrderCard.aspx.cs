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
    public partial class OrderCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((User)Session["user"]).UserRole != "Customer")
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindCardData();
            }
        }

        private void BindCardData()
        {
            List<Card> cards;
            string searchTerm = Request.QueryString["search"];

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Jika ada pencarian, filter berdasarkan nama [cite: 62]
                cards = CardRepository.SearchCardsByName(searchTerm);
            }
            else
            {
                // Jika tidak, tampilkan semua kartu [cite: 65]
                cards = CardRepository.GetAllCards();
            }

            CardRepeater.DataSource = cards;
            CardRepeater.DataBind();
        }

        protected void CardRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                User currentUser = (User)Session["user"];
                int cardId = Convert.ToInt32(e.CommandArgument);

                // Temukan textbox quantity di dalam item repeater yang diklik
                TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
                int quantity = Convert.ToInt32(txtQuantity.Text);

                // Panggil handler untuk menambahkan ke keranjang
                string result = CartHandler.AddToCart(currentUser.UserID, cardId, quantity);

                lblMessage.Text = result;
                lblMessage.Visible = true;
            }
        }
    }
}