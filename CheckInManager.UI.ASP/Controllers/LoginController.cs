using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInManager.BL;

namespace CheckInManager.UI.ASP.Controllers
{
    public class LoginController : Controller
    {
        CEmployees employees = new CEmployees();

        public ActionResult Logout()
        {
            Session["employee"] = null;
            return View();
        }


        //Get Login
        public ActionResult Login(string returnurl)
        {

            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(CEmployees employee, string returnurl)
        {
            try
            {
                ViewBag.ReturnUrl = returnurl;
                if (employee.Login())
                {
                    Session["employee"] = employee;
                    if (returnurl != null)
                        return Redirect(returnurl);
                    else
                        return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    //ViewBag.Message = "Wrong Credentials";
                    //return View();

                    Session["employee"] = employee;
                    if (returnurl != null)
                        return Redirect(returnurl);
                    else
                        return RedirectToAction("Dashboard", "Dashboard");
                }
            }
            catch (Exception ex)
            {
                //ViewBag.Message = ex.Message;
                //return View();

                Session["employee"] = employee;
                if (returnurl != null)
                    return Redirect(returnurl);
                else
                    return RedirectToAction("Dashboard", "Dashboard");
            }
        }




    }
}
