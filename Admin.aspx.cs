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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is a page only Admin users have right to access. At page load we check to see if the user
            //has Admin status, if they do not they are redirected to the Welcome page (Main).
            User u = (User)Session["user"];
            bool isAdmin = u is Admin;
            if (!isAdmin)
            {
                Response.Redirect("Main.aspx");
            }

            if (!IsPostBack)
            {
                //Bind the users to the gridview.
                gvUsers.DataSource = BindUsers();
                gvUsers.DataBind();
            }
        }

        /// <summary>
        /// calls the database and gets back all registered users.
        /// </summary>
        /// <returns></returns>
        private DataSet BindUsers()
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            DataSet ds = d.ExecuteProcedure("spGetUsersForAdmin");
            return ds;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        /// <summary>
        /// allows the Admin user to delete any users who might have not been following the 
        /// policies of the social networking site. They are deleted from all tables in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gvUsers.SelectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
            int userId = Convert.ToInt32(gvUsers.SelectedValue.ToString());

            if (e.CommandName == "Delete User")
            {
                DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                d.AddParam("@UserId", gvUsers.SelectedValue.ToString());
                DataSet ds = d.ExecuteProcedure("spDeleteUser");

                Alerts.Show("User Deleted!");

                gvUsers.DataSource = BindUsers();
                gvUsers.DataBind();
            }
        }

        /// <summary>
        /// allows the Admin user to view users in pages rather than on one huge page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.DataSource = BindUsers();
            gvUsers.PageIndex = e.NewPageIndex;
            gvUsers.DataBind();
        }
    }
}