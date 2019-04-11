using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInManager.BL;
using CheckInManager.UI.ASP.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;



namespace CheckInManager.UI.ASP.Controllers
{
    public class GuestController : Controller
    {

        //Authenticate
        public ActionResult Guest()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                return RedirectToAction("AddGuest", "Guest");
            }
            
        }

   
        public ActionResult AddGuest()
        {
            GuestEvent ge = new GuestEvent();
            CGuest guest = new CGuest();
            CEvents events = new CEvents();

            ge.Guest = guest;
            ge.Events = events;

            return View();
        }

        [HttpPost]
        public ActionResult AddGuest(GuestEvent ge)
        {

            try
            {
                ge.Guest.EventID = (int)Session["eventid"];
                ge.Guest.Insert();
                return RedirectToAction("AddGuest","Guest");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }


        //string gender = guest.Gender;
        //string age = guest.AgeGroup;
        //string ethnicity = guest.Ethnicity;
        //string city = guest.City;
        //bool repeat = guest.Repeat;
        //guest.EventID = (int) Session["eventid"];
        //guest.Insert();
        //    return View();

    }
}