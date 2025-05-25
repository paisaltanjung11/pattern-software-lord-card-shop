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
    public partial class EditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((User)Session["user"]).UserRole != "Admin")
            {
                Response.Redirect("Login.aspx");
                return; 
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("ManageCard.aspx");
                    return;
                }

                int cardId;
                if (!int.TryParse(Request.QueryString["id"], out cardId))
                {
                    Response.Redirect("ManageCard.aspx");
                    return;
                }

                Card card = CardRepository.GetCardById(cardId);

                if (card == null)
                {
                    Response.Redirect("ManageCard.aspx");
                    return;
                }

                txtName.Text = card.CardName;
                txtPrice.Text = card.CardPrice.ToString();
                txtDescription.Text = card.CardDesc;

                if (ddlType.Items.FindByValue(card.CardType) != null)
                {
                    ddlType.SelectedValue = card.CardType;
                }

                string isFoilValue = (card.IsFoil != null && card.IsFoil.Length > 0 && card.IsFoil[0] == 1) ? "Yes" : "No";
                if (ddlFoil.Items.FindByValue(isFoilValue) != null)
                {
                    ddlFoil.SelectedValue = isFoilValue;
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int cardId = Convert.ToInt32(Request.QueryString["id"]);
            string name = txtName.Text;
            string price = txtPrice.Text;
            string desc = txtDescription.Text;
            string type = ddlType.SelectedValue;
            string foil = ddlFoil.SelectedValue;

            string result = CardHandler.UpdateCard(cardId, name, price, desc, type, foil);

            if (result == "success")
            {
                Response.Redirect("ManageCard.aspx");
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}