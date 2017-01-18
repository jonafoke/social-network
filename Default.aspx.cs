//summary
//Jonathan Fokeer
//Dec 15, 2014

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// checks to make sure all info required is there, then registers the new user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //a series of IF statements to ensure all required fields are full.
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                Alerts.Show("You must enter a First Name.");
            }
            else if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                Alerts.Show("You must enter a Last Name.");
            }
            else if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                Alerts.Show("You must enter a Phone number.");
            }
            else if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                Alerts.Show("You must enter a City.");
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                Alerts.Show("You must enter an Email address.");
            }
            else if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                Alerts.Show("You must enter a Username.");
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Alerts.Show("You must enter a Password.");
            }

            string profilePic = "";

            //Check if the file upload has a file
            if (uploadPhoto.HasFile)
            {
                //Get the file name from the file upload
                profilePic = uploadPhoto.FileName;
            }


            try
            {
                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string phone = txtPhone.Text;
                string city = txtCity.Text;
                string email = txtEmail.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                int accessLevel = 1;

                d.AddParam("FirstName", firstName);
                d.AddParam("LastName", lastName);
                d.AddParam("phone", phone);
                d.AddParam("city", city);
                d.AddParam("email", email);
                d.AddParam("username", username);
                d.AddParam("password", password);
                d.AddParam("profilePic", "~/images/" + profilePic);
                d.AddParam("accessLevel", accessLevel);

                uploadPhoto.SaveAs(Server.MapPath(".") + profilePic);

                DataSet ds = d.ExecuteProcedure("spAddUser");

                Alerts.Show("Registration done successfully. You may now log in!");
                clearControls();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// clears all of the textboxes.
        /// </summary>
            private void clearControls()
    {
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtPhone.Text = string.Empty;
        txtCity.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtUsername.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }
        
    }
}