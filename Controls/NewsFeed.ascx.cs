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
    public partial class NewsFeed : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                LatestUpdates();
            
        }

        /// <summary>
        /// calls the database and returns the "latest updates" to the News Feed datalist. Displays the
        /// full name of the logged on user.
        /// </summary>
        private void LatestUpdates()
        {
            if (Session["FullName"] != null)
            {
                lblName.Text = Session["FullName"].ToString();
            }

            if (Session["UserId"] != null)
            {
                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                DataSet ds = d.ExecuteProcedure("spGetStatus");
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    dlPosts.Visible = true;
                    dlPosts.DataSource = dt;
                    dlPosts.DataBind();
                }
                else
                {

                }
            }
            else
            {
                Alerts.Show("No Current User Session");
            }

        }

        /// <summary>
        /// This button click takes the text to be displayed on the news feed by the user, and 
        /// enters it into the Status Update table in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                string update = txtWhatsOnYourMind.Text;
                string userId = Session["UserId"].ToString();
                DateTime postDate = DateTime.Now;

                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                d.AddParam("Update", update);
                d.AddParam("UserID", userId);
                d.AddParam("PostDate", postDate);
                DataSet ds = d.ExecuteProcedure("spInsertStatus");
            }

            LatestUpdates();
            txtWhatsOnYourMind.Text = string.Empty;

        }

       

        protected void YourPic_Click(object sender, ImageClickEventArgs e)
        {

        }
        
    }
}