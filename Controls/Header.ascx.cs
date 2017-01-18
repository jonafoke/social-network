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
using System.Configuration;

namespace Assignment_4_2.Controls
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //On page load, we want to check to see if the logged on user has any messages. If they do
            //we change the Mail image to show a large envelope.
            if (Session["UserId"] != null)
            {
                string toUserId = Session["UserId"].ToString();
                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                d.AddParam("@ToUserID", toUserId);
                DataSet ds = d.ExecuteProcedure("spGetMessagesByUserID");

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // Change the image to an image that indicates there is a new message:
                    imgBtnMsg.ImageUrl = "~/images/checkmark.jpg";
                }
            }
        }

        protected void btnLogo_Click(object sender, EventArgs e)
        {
            

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["SearchText"] = txtSearch.Text;
            Response.Redirect("~/Search.aspx");
        }

        protected void imgBtnMsg_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Messages.aspx");
        }

        protected void imgBtnMain_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

    }
}