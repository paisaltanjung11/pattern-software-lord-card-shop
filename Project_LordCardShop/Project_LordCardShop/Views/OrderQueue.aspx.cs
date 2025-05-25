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
    public partial class OrderQueue : System.Web.UI.Page
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
                BindQueues();
            }
        }
        private void BindQueues()
        {
            List<TransactionHeader> allTransactions = TransactionRepository.GetAllTransactions();
            List<TransactionHeader> unhandled = allTransactions.Where(t => t.Status == "Unhandled").ToList();
            List<TransactionHeader> handled = allTransactions.Where(t => t.Status == "Handled").ToList();

            UnhandledGridView.DataSource = unhandled;
            UnhandledGridView.DataBind();

            HandledGridView.DataSource = handled;
            HandledGridView.DataBind();
        }
        protected void UnhandledGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Handle")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                TransactionHandler.HandleTransaction(transactionId);

                lblMessage.Text = "Transaction ID " + transactionId + " has been handled successfully.";
                lblMessage.Visible = true;
                BindQueues();
            }
        }
    }
}