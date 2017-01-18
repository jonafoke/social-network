//summary
//Jonathan Fokeer
//Dec 15, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace Assignment_4_2.Controls
{
    public partial class FriendRequests : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowFriendRequests();
            }
        }

        /// <summary>
        /// This method calls the database and returns back any friend requests the logged on user
        /// has based on their UserId. If they don't have any then an alert saying so is shown.
        /// </summary>
        private void ShowFriendRequests()
        {
            string ToUserID = Session["UserId"].ToString();

            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            d.AddParam("@ToUserID", ToUserID);
            DataSet ds = d.ExecuteProcedure("spShowFriendRequestsToUserID");

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                    dlFriendRequests.DataSource = dt;
                    dlFriendRequests.DataBind();
                }
                else
                {
                    Alerts.Show("You have no Friend Requests at the moment.");
                }
            }
        }

        protected void imgbtnYou_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["ProfileId"] != null)
            {
                Session["ProfileId"] = (((ImageButton)sender).CommandArgument).ToString();
                Response.Redirect("Main.aspx");
            }
        }

        //If friend requests are shown, the logged on user can either "accept" them or "reject"
        //them. If "accept" is clicked, the new friendship is entered into the database. This is marked
        //with a "1" in the database column to show it was accepted.
        protected void btnAccept_Click(object sender, EventArgs e)
        { 
            if (Session["UserId"] != null)
            {
                string SenderFriendId = (((Button)sender).CommandArgument).ToString();
                string UserID = Session["UserId"].ToString();
                DateTime dateAccepted = DateTime.Now;

                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                d.AddParam("@UserID", UserID);
                d.AddParam("@FriendUserID", SenderFriendId);
                d.AddParam("@DateAccepted", dateAccepted);
                DataSet ds = d.ExecuteProcedure("spAcceptFriend");

                Response.Redirect("~/Friends.aspx");
            }
        }

        //If "reject" is clicked, the friend request is deleted and no new friendship is registered. This is 
        //marked with a "2" in the database to show this request was not accepted.
        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                string SenderFriendId = (((Button)sender).CommandArgument).ToString();
                string MyID = Session["UserId"].ToString();
                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                d.AddParam("@FriendUserID", SenderFriendId);
                DataSet ds = d.ExecuteProcedure("spRejectFriend");

                Response.Redirect("~/Friends.aspx");
            }
        }

        protected void dlFriendRequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
        