using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckInManager.UI.ASP.Models
{
    public static class CCredentials
    {
        public static bool CredentialsExist()
        {
            if (HttpContext.Current.Session == null)
                return false;
            else
                return (HttpContext.Current.Session["employee"]) != null;
        }
    }
}