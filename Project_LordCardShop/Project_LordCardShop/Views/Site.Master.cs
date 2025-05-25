using Project_LordCardShop.Models;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_LordCardShop.Views
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sembunyikan semua panel navigasi terlebih dahulu
            pnlGuestNav.Visible = false;
            pnlCustomerNav.Visible = false;
            pnlAdminNav.Visible = false;
            pnlLogout.Visible = false;

            if (Session["user"] == null)
            {
                // Tampilkan navigasi untuk Guest
                pnlGuestNav.Visible = true;
                lblWelcome.Text = "Welcome, Guest";
            }
            else
            {
                // Tampilkan tombol logout dan pesan selamat datang
                pnlLogout.Visible = true;
                User currentUser = (User)Session["user"];
                lblWelcome.Text = "Welcome, " + currentUser.UserName;

                // Tampilkan navigasi berdasarkan role user
                if (currentUser.UserRole == "Admin")
                {
                    pnlAdminNav.Visible = true;
                }
                else
                {
                    pnlCustomerNav.Visible = true;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Hapus sesi
            Session.Abandon();

            // Hapus cookie jika ada
            if (Request.Cookies["user_cookie"] != null)
            {
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            // Redirect ke halaman login
            Response.Redirect("~/Views/Login.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            string role = "Guest";

            if (Session["user"] != null)
            {
                role = ((User)Session["user"]).UserRole;
            }

            // Redirect ke halaman yang sesuai berdasarkan role
            if (role == "Admin")
            {
                Response.Redirect($"~/Views/ManageCard.aspx?search={searchTerm}");
            }
            else
            {
                Response.Redirect($"~/Views/OrderCard.aspx?search={searchTerm}");
            }
        }
    }
}