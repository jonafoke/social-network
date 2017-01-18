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
    public partial class WebForm6 : System.Web.UI.Page
    {
        User u;

        protected void Page_Load(object sender, EventArgs e)
        {
            //checks to see that there is a logged in user.
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            u = (User)Session["user"];

            if (!IsPostBack)
            {
                gvMessages.DataSource = RefreshMessages();
                gvMessages.DataBind();
            }
        }

        /// <summary>
        /// this method gets the messages of the logged on user from the database.
        /// </summary>
        /// <returns></returns>
        private DataSet RefreshMessages()
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            if (Session["SortColumn"] != null)
            {
                d.AddParam("SortColumn", Session["SortColumn"].ToString());
            }
                string toUserID = Session["UserId"].ToString();
                d.AddParam("@ToUserID", toUserID);
                return d.ExecuteProcedure("spGetMessagesByUserID");
            
        }

        /// <summary>
        /// lets the user sort the columns in the gridview if they so choose.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvMessages_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            gvMessages.DataSource = RefreshMessages();
            gvMessages.DataBind();
        }

        /// <summary>
        /// if the user has a lot of messages and they don't delete any, this will let them view
        /// multiple pages instead of all of them on one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMessages.DataSource = RefreshMessages();
            gvMessages.PageIndex = e.NewPageIndex;
            gvMessages.DataBind();
        }
    }
}