using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_LordCardShop.Models;
using Project_LordCardShop.Repositories;

namespace Project_LordCardShop.Views
{
    public partial class CardDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((User)Session["user"]).UserRole != "Customer")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadCardData();
            }
        }
        private void LoadCardData()
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("OrderCard.aspx");
                return;
            }

            int cardId;
            if (!int.TryParse(Request.QueryString["id"], out cardId))
            {
                Response.Redirect("OrderCard.aspx");
                return;
            }

            Card card = CardRepository.GetCardById(cardId);

            if (card == null)
            {
                Response.Redirect("OrderCard.aspx");
                return;
            }

            lblName.Text = card.CardName;
            lblPrice.Text = "Rp " + card.CardPrice.ToString("N0");
            lblType.Text = card.CardType;
            lblDesc.Text = card.CardDesc;
            lblFoil.Text = (card.IsFoil != null && card.IsFoil.Length > 0 && card.IsFoil[0] == 1) ? "Yes" : "No";
        }
    }
}