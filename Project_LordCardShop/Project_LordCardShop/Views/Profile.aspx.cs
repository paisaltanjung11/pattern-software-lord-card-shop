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
    public partial class Profile : System.Web.UI.Page
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
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
        {
            User currentUser = (User)Session["user"];

            txtUsername.Text = currentUser.UserName;
            txtEmail.Text = currentUser.UserEmail;

            if (rblGender.Items.FindByValue(currentUser.UserGender) != null)
            {
                rblGender.SelectedValue = currentUser.UserGender;
            }

            txtDob.Text = currentUser.UserDOB.ToString("yyyy-MM-dd");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User currentUser = (User)Session["user"];
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string gender = rblGender.SelectedValue;
            string dob = txtDob.Text;
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            string result = UserHandler.UpdateProfile(currentUser.UserID, username, email, gender, dob, oldPassword, newPassword, confirmPassword);

            if (result == "success")
            {
                lblMessage.Text = "Profile updated successfully!";
                lblMessage.ForeColor = Color.Green;
                Session["user"] = UserRepository.GetUserById(currentUser.UserID);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}