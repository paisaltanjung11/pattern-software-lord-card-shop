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
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadTransactionDetails();
            }
        }
        private void LoadTransactionDetails()
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("TransactionHistory.aspx");
                return;
            }

            int transactionId;
            if (!int.TryParse(Request.QueryString["id"], out transactionId))
            {
                Response.Redirect("TransactionHistory.aspx");
                return;
            }

            TransactionHeader header = TransactionRepository.GetTransactionHeaderById(transactionId);
            if (header == null)
            {
                Response.Redirect("TransactionHistory.aspx");
                return;
            }

            User currentUser = (User)Session["user"];
            if (currentUser.UserRole == "Customer" && header.CustomerID != currentUser.UserID)
            {
                Response.Redirect("TransactionHistory.aspx");
                return;
            }

            lblTransactionId.Text = header.TransactionID.ToString();
            lblDate.Text = header.TransactionDate.ToString("D");
            lblCustomer.Text = header.User.UserName;
            lblStatus.Text = header.Status;

            List<TransactionDetail> details = TransactionRepository.GetDetailsByTransactionId(transactionId);
            DetailGridView.DataSource = details;
            DetailGridView.DataBind();
        }
        protected void DetailGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TransactionDetail detailItem = (TransactionDetail)e.Row.DataItem;
                double price = detailItem.Card.CardPrice;
                int quantity = detailItem.Quantity;
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
    }
}