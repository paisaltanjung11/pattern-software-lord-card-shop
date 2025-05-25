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
    public partial class ManageCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((User)Session["user"]).UserRole != "Admin")
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindGridData();
            }
        }
        private void BindGridData()
        {
            List<Card> cards;
            string searchTerm = Request.QueryString["search"];

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Handle pencarian dari navbar
                cards = CardRepository.SearchCardsByName(searchTerm);
            }
            else
            {
                cards = CardRepository.GetAllCards();
            }

            CardGridView.DataSource = cards;
            CardGridView.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCard.aspx");
        }

        protected void CardGridView_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int cardId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "UpdateCard")
            {
                Response.Redirect($"EditCard.aspx?id={cardId}");
            }
            else if (e.CommandName == "DeleteCard")
            {
                CardRepository.DeleteCard(cardId);
                BindGridData();
            }
        }
    }
}