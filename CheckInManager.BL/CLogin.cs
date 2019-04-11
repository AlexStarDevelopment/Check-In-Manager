using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

//This may come in handy later. This will tell us the current user that is logged in

namespace CheckInManager.BL
{
    public static class CUserLoggedIn
    {
        public static int UserLoggedIn { get; set; }


        public static void set(int id)
        {
            UserLoggedIn = id;
        }
    }
    
}
