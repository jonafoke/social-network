//summary
//Jonathan Fokeer
//Dec 15, 2014

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Web.Configuration;
 

namespace Assignment_4_2
{
    /// <summary>
    /// This WebService works with the AJAX Autocomplete Extender that is used with the txtSearch textbox.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoCompleteService : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] SearchFriends(string prefixText)
        {
            //takes in the prefixText variable from the txtSearch textbox and passes it in a database query
            //which is then checked against EACH name in the database. Any potential matches are shown in
            //a box under the textbox.
            SqlConnection conn = new SqlConnection(@"Data Source = localhost; Initial Catalog = dbFriendBook; Integrated Security=SSPI");
            string sql = "Select * from tbProfileInfo Where FirstName like @prefixText";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["FirstName"].ToString(), i);
                i++;
            }
            return items;
        }
    }
}
