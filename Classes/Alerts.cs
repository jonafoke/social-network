//summary
//Jonathan Fokeer
//Dec 15, 2014

using System.Web;
using System.Text;
using System.Web.UI;

namespace Assignment_4_2
{
 
/// <summary>
/// A JavaScript alert
/// </summary>
    public static class Alerts
    {

        /// <summary>
        /// Shows a client-side JavaScript alert in the browser. I found creating a Class for
        /// the alerts saves time in the long run because you can create an alert from
        /// anywhere in the project very quickly.
        /// </summary>
        /// The message to appear in the alert.
        public static void Show(string message)
        {
            string cleanMessage = message.Replace("'", "\'");
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("alert('{0}');", cleanMessage);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true);
            } 
        }
    }
}
    