//summary
//Jonathan Fokeer
//Dec 15, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4_2.Classes
{
    class Admin : User
    {
        public Admin(int userId, int accessLevel)
            : base(userId, accessLevel)
        {
            // Calls the parent class's constructor
        }
    }
}