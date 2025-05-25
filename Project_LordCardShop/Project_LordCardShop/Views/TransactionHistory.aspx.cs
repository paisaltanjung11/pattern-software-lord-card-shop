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
    public partial class TransactionHistory : System.Web.UI.Page
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
                BindHistoryData();
            }
        }

        private void BindHistoryData()
        {
            User currentUser = (User)Session["user"];
            List<TransactionHeader> transactions;

            if (currentUser.UserRole == "Admin")
            {
                transactions = TransactionRepository.GetAllTransactions(); // liat smua transaksi
                HistoryGridView.Columns[2].Visible = true; // tampilan kolom cust
            }
            else // customer
            {
                transactions = TransactionRepository.GetTransactionsByUserId(currentUser.UserID); // cust hanya bs liat transaksi sndiri
                HistoryGridView.Columns[2].Visible = false; // hide kolom cust
            }
            if (transactions.Count == 0)
            {
                lblNoTransactions.Visible = true;
                HistoryGridView.Visible = false;
            }
            else
            {
                lblNoTransactions.Visible = false;
                HistoryGridView.Visible = true;
                HistoryGridView.DataSource = transactions;
                HistoryGridView.DataBind();
            }
        }
    }
}