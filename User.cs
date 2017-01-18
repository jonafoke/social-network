//summary
//Jonathan Fokeer
//Dec 15, 2014

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Assignment_4_2.Classes
{
    class User
    
    {
        //PROPERTIES
        public int UserId { get; set; }

        public string userName { get; set; }

        public int accessLevel { get; set; }


        //CONSTRUCTORS
        public User(int UserID, int accessLevel)
        {
            //Calls the database and gets the user's information
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            d.AddParam("@UserId", UserID);
            DataSet ds = d.ExecuteProcedure("spGetUsers");

            if (ds.Tables[0].Rows.Count > 0)
            {
                UserId = (int)ds.Tables[0].Rows[0]["UserID"];
                userName = ds.Tables[0].Rows[0]["UserName"].ToString();
                accessLevel = (int)ds.Tables[0].Rows[0]["AccessLevel"];
            }
            else
            {
                throw new Exception(String.Format("ERROR!  No User ID found for UserID {0}", UserID));
            }
        }

        public User() { }
        
    }
}