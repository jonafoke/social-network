//summary
//Jonathan Fokeer
//Dec 15, 2014

using Assignment_4_2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        User u;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ensures there is a logged on user.
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            u = (User)Session["user"];
        }
    }
}