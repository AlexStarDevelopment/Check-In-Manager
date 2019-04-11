using CheckInManager.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CheckInManager.BackEndUI
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ValidateUser(object sender, EventArgs e)
        {
            //CEmployees employee = new CEmployees();
            //bool valid = false;
            //valid = employee.Login(Login1.UserName, Login1.Password);
            //if (valid == true)
            //{
            //    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            //    Response.Redirect("GuestData.aspx");
            //}
            //else
            //{
            //    Login1.FailureText = "Username and/or password is incorrect.";
            //}
        }
    }
}