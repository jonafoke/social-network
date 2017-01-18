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
    public partial class Search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSearchResults();
            }
        }

        /// <summary>
        /// uses the search bar to look for potential friends. This is one of the ways someone can look
        /// and see who is on the FriendBook site. Takes in the text entered and searches the database
        /// to try and find a match. If there is a match it is shown in thr datalist.
        /// </summary>
        private void GetSearchResults()
    {
        string searchText = Session["SearchText"].ToString();
        DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        d.AddParam("@SearchText", searchText);
        DataSet ds = d.ExecuteProcedure("spSearch");
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
 
            SearchList.Visible = true;
            SearchList.DataSource = dt;
            SearchList.DataBind();
        }
        else
        {
 
        }
    }
 
    protected void imgbtnPic_Click(object sender, ImageClickEventArgs e)
    {
        Session["ProfileId"] = (((ImageButton)sender).CommandArgument).ToString();
        Response.Redirect("Main.aspx");
    }
    }
}