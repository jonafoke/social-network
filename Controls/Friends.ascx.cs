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
    public partial class Friends : System.Web.UI.UserControl
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    MyFriends();
                }
                else
                {
                    Response.Redirect("Main.aspx");
                }
            }
        }

        /// <summary>
        /// The method to populate the Friends datalist upon page load.
        /// </summary>
        private void MyFriends()
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            d.AddParam("UserID", Session["UserID"].ToString());
            DataSet ds = d.ExecuteProcedure("spReturnFriendsByUserID");
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                dlFriends.DataSource = dt;
                dlFriends.DataBind();
            }
        }

    protected void imgbtnYou_Click(object sender, ImageClickEventArgs e)
    {
        Session["ProfileId"]=(((ImageButton)sender).CommandArgument).ToString();
        Response.Redirect("Main.aspx");
    }

    }
}