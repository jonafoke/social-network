//summary
//Jonathan Fokeer
//Dec 15, 2014

using Assignment_4_2.Classes;
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
    public partial class WebForm5 : System.Web.UI.Page
    {
        User u;
        int profileID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //makes sure there is a logged on user.
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            u = (User)Session["user"];

            if (Request.QueryString["ProfileID"] != null)
            {
                profileID = Convert.ToInt32(Request.QueryString["ProfileID"]);

                if (!IsPostBack)
                {
                    //gets ProfileID for about me page being viewed
                    
                        pnlProfile.Visible = false;

                        DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                        d.AddParam("@ProfileID", profileID);
                        DataSet ds = d.ExecuteProcedure("spGetProfileByProfileID");

                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            lblFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                            lblLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                            lblPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                            lblCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            int profileViewId = (int)ds.Tables[0].Rows[0]["ProfileID"];
                            
                        }
                    
                }
                //take logged on User's ID and check if it matches the ProfileID on this AboutMe. Change 
                //button visibility appropriately.
                if (Convert.ToInt32(Session["UserId"]) == profileID)
                {
                    btnEdit.Visible = true;
                    btnAddAsFriend.Visible = false;
                }
                else
                {
                    btnEdit.Visible = false;
                    btnAddAsFriend.Visible = true;
                }
                
            }
               
        }
       
        /// <summary>
        /// shows fields that can be used to edit the user's profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Edit_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                pnlProfile.Visible = true;

            }
        }

        /// <summary>
        /// if viewing someone else's page, allows the logged in user to send a friend request. Also
        /// checks to see if friend request was accepted, pending, or denied.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddAsFriend_Click(object sender, EventArgs e)
        {
             if (Session["UserId"] != null)
            {
                if (Convert.ToInt32(Session["UserId"]) != profileID)
                {
                    string userId = Session["UserId"].ToString();
                    
                    DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                    d.AddParam("@UserId", userId);
                    d.AddParam("@CurrentProfileId", profileID);
                    DataSet ds = d.ExecuteProcedure("spCheckFriendRequest");

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["FriendStatus"].ToString() == "1")
                        {
                            Alerts.Show("Already in friend list");
                            btnAddAsFriend.Visible = false;

                        }
                        else if (ds.Tables[0].Rows[0]["FriendStatus"].ToString() == "0")
                        {
                            btnAddAsFriend.Visible = true;
                            btnAddAsFriend.Text = "Friend Request Pending";
                            btnAddAsFriend.Enabled = false;
                        }
                        else if (ds.Tables[0].Rows[0]["FriendStatus"].ToString() == "2")
                        {
                            Alerts.Show("Friend Request denied");
                        }
                    }
                        //if this is the first time the "Add as Friend" button was clicked, then this code
                        //is run instead and a friend request gets sent.
                    else
                    {
                        int status = 0;
                        DateTime date = DateTime.Now;

                        DAL_Project.DAL dp = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                        dp.AddParam("UserID", userId);
                        dp.AddParam("CurrentProfileID", profileID);
                        dp.AddParam("DateSent", date);
                        dp.AddParam("Status", status);
                        dp.ExecuteProcedure("spSendFriendRequest");

                        btnAddAsFriend.Text = "Friend Request Sent.";
                    }
                } 
            }
        }

        /// <summary>
        /// Sends the new upadated information for the logged on user's profile and updates the database
        /// accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string profilePic = "";

                //Check if the file upload has a file
                if (uploadNewPhoto.HasFile)
                {
                    //Get the file name from the file upload
                    profilePic = uploadNewPhoto.FileName;
                }

                string profileId = Session["UserId"].ToString();

                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                d.AddParam("@ProfileID", profileId);
                d.AddParam("@FirstName", txtFirstName.Text);
                d.AddParam("@LastName", txtLastName.Text);
                d.AddParam("@Phone", txtPhone.Text);
                d.AddParam("@City", txtCity.Text);
                d.AddParam("@ProfilePic", profilePic);

                uploadNewPhoto.SaveAs(Server.MapPath(".") + profilePic);

                d.ExecuteProcedure("spUpdateProfile");
                Alerts.Show("Changes Saved!");
            
        }
    }
}