using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_LordCardShop.Handlers;

namespace Project_LordCardShop.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string gender = rblGender.SelectedValue;
            string dob = txtDob.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            string result = UserHandler.RegisterUser(username, email, password, confirmPassword, gender, dob);

            if (result == "success")
            {
                lblMessage.Text = "Registration successful! Please login.";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = result; // Tampilkan pesan error dari Handler [cite: 49]
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}