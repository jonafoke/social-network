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

namespace Assignment_4_2.Controls
{
    public partial class ProfilePic : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetProfilePic();
            }
        }

        /// <summary>
        /// On page load, gets the logged on user's info from the database, and displays their photo.
        /// </summary>
        private void GetProfilePic()
        {
            if (Session["UserID"] != null)
            {
                string profileID = Session["ProfileId"].ToString();

                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                d.AddParam("@ProfileID", profileID);
                DataSet ds = d.ExecuteProcedure("spGetProfileByProfileID");

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        dlProfile.Visible = true;
                        Session["FullName"] = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["LastName"];
                        dlProfile.DataSource = dt;
                        dlProfile.DataBind();
                    }
                    else
                    {

                    }
                }
                else
                {
                    Alerts.Show("No Current Profile Session");
                }
            }
        }
        protected void btnAboutMe_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboutMe.aspx");
        }
        protected void btnFriends_Click(object sender, EventArgs e)
        {
            Response.Redirect("Friends.aspx");
        }
    }
}