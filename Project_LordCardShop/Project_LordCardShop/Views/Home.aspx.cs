using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // buat user yg ud login
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                User currentUser = (User)Session["user"];
                lblWelcomeMessage.Text = "Hello, " + currentUser.UserName + "!";
            }
        }
    }
}