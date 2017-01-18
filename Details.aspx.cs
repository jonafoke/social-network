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
    public partial class WebForm7 : System.Web.UI.Page
    {
        int messageID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //on page load we have to check to see what messageId was passed in the query string.
             if (Request.QueryString["MessageID"] != null)
            {
                messageID = Convert.ToInt32(Request.QueryString["MessageID"]);

                if (!IsPostBack)
                {
                    DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                    d.AddParam("@MessageID", messageID);
                    DataSet ds = d.ExecuteProcedure("spGetMessageByMessageID");

                    // Once we get the Message based on the MessageID, we check that the resulting message exists and that it belongs to the user who is logged in.
                    // note that if we don't do this last check, we could read ANY message from anyone. Not good.
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0
                        && ds.Tables[0].Rows[0]["ToUserID"].ToString() == Session["UserId"].ToString())
                    {
                        lblDate.Text = ds.Tables[0].Rows[0]["DateReceived"].ToString();
                        lblFrom.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        lblMessage.Text = ds.Tables[0].Rows[0]["MessageBody"].ToString();
                        lblFromUserID.Text = ds.Tables[0].Rows[0]["FromUserID"].ToString(); // need to keep track of this for later
                    }
                    else
                    {
                        // It was a bad MessageID, or a Message NOT for the logged in user, BUMP 'em back!
                        // probably should provide an error though.
                        Response.Redirect("Messages.aspx");
                    }
                }
            }
             else
             {
                 // no messageID in query string, bump em back!
                 Response.Redirect("Messages.aspx");
             }
            //mark current message as "read" by changing status to 1
             DAL_Project.DAL dd = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
             dd.AddParam("@MessageID", messageID);
             DataSet ds1 = dd.ExecuteProcedure("spMarkMessageAsRead");

             pnlReply.Visible = false;
        }

        /// <summary>
        /// allows us to open up a panel for replying to the message being viewed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReply_Click(object sender, EventArgs e)
        {
            pnlReply.Visible = true;
        }

        /// <summary>
        /// deletes the message being viewed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            d.AddParam("@MessageID", messageID); // on page load messageID is set from the query string.
            d.ExecuteProcedure("spDeleteMessage");
            Alerts.Show("Message Deleted");
            Response.Redirect("Messages.aspx");

        }

        /// <summary>
        /// sends the reply message and updates the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtReplyMessage.Text;
            string toUserId = lblFromUserID.Text; // the original message was from this user id.. it's now the toUserId.
            string fromUserId = Session["UserId"].ToString();
            int readStatus = 1;
            DateTime date = DateTime.Now;

            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            d.AddParam("ToUserID", toUserId);
            d.AddParam("FromUserID", fromUserId);
            d.AddParam("MessageBody", message);
            d.AddParam("ReadStatus", readStatus);
            d.AddParam("DateReceived", date);

            DataSet ds = d.ExecuteProcedure("spInsertMessage");
            txtReplyMessage.Text = string.Empty;
            Alerts.Show("Message Sent.");
        }
    }
}