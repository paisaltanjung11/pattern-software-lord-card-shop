using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_LordCardShop.Handlers;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Views
{
    public partial class AddCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((User)Session["user"]).UserRole != "Admin")
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string price = txtPrice.Text;
            string desc = txtDescription.Text;
            string type = ddlType.SelectedValue;
            string foil = ddlFoil.SelectedValue;
            string result = CardHandler.InsertCard(name, price, desc, type, foil);

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