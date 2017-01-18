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
using Assignment_4_2.Classes;

namespace Assignment_4_2
{
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Our login click that logs the user in. Here we allso assign Session variables and 
        /// determine whether or not the user is Admin. They get redirected appropriately.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            d.AddParam("@Username", txtUsername.Text);
            d.AddParam("@Password", txtLoginPassword.Text);

            DataSet ds = d.ExecuteProcedure("spLogin");
            
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                DataTable dt = ds.Tables[0];
                Session["ProfileId"] = dt.Rows[0]["ProfileId"];
                Session["UserId"] = dt.Rows[0]["UserID"];
                Session["AccessLevel"] = dt.Rows[0]["AccessLevel"];
                Session["UserName"] = dt.Rows[0]["UserName"];
                Session["FullName"] = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["LastName"];

                int userId = (int)ds.Tables[0].Rows[0]["UserID"];
                int accessLevel = (int)ds.Tables[0].Rows[0]["AccessLevel"];

                // Access is based on access level, not user ID 
                if (accessLevel == 1)
                {
                    Session["user"] = new User(userId, accessLevel);
                    Response.Redirect("~/Main.aspx");
                }
                //if the user is an Admin, they are redirected to the Admin page.
                else
                {
                    Session["user"] = new Admin(userId, accessLevel); ;
                    Response.Redirect("Admin.aspx");
                }

            }
            else
            {
                Alerts.Show("Incorrect UserName/Password ");
            }
        }
    }
}