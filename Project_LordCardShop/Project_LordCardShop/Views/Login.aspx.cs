using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_LordCardShop.Handlers;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Jika user sudah login, tendang ke halaman home
            if (Session["user"] != null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            // Cek cookie untuk login otomatis
            if (!IsPostBack && Request.Cookies["user_cookie"] != null)
            {
                string email = Request.Cookies["user_cookie"]["email"];
                // Di aplikasi nyata, cookie harus dienkripsi. Ini hanya untuk demo.
                // Anda perlu method di repository/handler untuk get user by email.
                // Anggap saja kita langsung login untuk simplifikasi.
                // txtEmail.Text = email; // Isi emailnya
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            User user = UserHandler.LoginUser(email, password);

            if (user != null)
            {
                Session["user"] = user;
                if (chkRememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie["email"] = user.UserEmail;
                    cookie.Expires = DateTime.Now.AddDays(1); // Cookie expired 1 hari [cite: 46]
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                lblError.Text = "Invalid email or password!";
        }
        }
    }
}