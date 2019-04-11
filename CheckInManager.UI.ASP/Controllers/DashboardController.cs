using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInManager.BL;
using Newtonsoft.Json;
using CheckInManager.PL;
using System.ComponentModel.DataAnnotations;
using CheckInManager.UI.ASP.Models;
using System.Runtime.Serialization.Json;
using System.Windows.Forms.DataVisualization;

namespace CheckInManager.UI.ASP.Controllers
{
    public class DashboardController : Controller
    {
        
        public ActionResult Index()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
               
        }
        
    
        public ActionResult Dashboard()
        {
            LFGuestSystemEntities _db = new LFGuestSystemEntities();
            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new {returnurl = HttpContext.Request.Url});
            }
            else
            {
                try
                {
                   
                    DateTime today = DateTime.Now;
                    DateTime sixMonthsAgo = today.AddMonths(-6);
                    // or
                    //var lastYear = today.AddYears(-1).Year;

                    var Coord = (from x in _db.HistoricalDatas
                                 where x.Date >= sixMonthsAgo
                                 //where x.Date.Value.Year == lastYear
                                 orderby x.Date
                                 select new
                                 {
                                     x.Date,
                                     x.Guests
                                 }).ToList();
                    ViewBag.DataPoints = JsonConvert.SerializeObject(Coord, _jsonSetting);
                    //ViewBag.DataPoints = JsonConvert.SerializeObject(_db.tblEvents.ToList(), _jsonSetting);
                    return View();
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    return View("Error");
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return View("Error");
                }
            }
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            //return View();
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
        }

    }
}