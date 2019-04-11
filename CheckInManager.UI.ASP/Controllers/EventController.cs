using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInManager.BL;
using CheckInManager.UI.ASP.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CheckInManager.UI.ASP.Controllers
{
    public class EventController : Controller
    {
        CEvents o_event;
        CEventList o_events;
            
        // GET: Event
        public ActionResult Index()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                o_events = new CEventList();
                o_events.Load();
                ViewBag.Message = "All Active Events";
                return View(o_events);
            }
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            Session["eventid"] = id;
            o_event = new CEvents();
            o_event.LoadById(id);
            return View(o_event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                EventsSites oEvenSitesList = new EventsSites();

                CSiteList allsites = new CSiteList();
                allsites.Load();

                oEvenSitesList.AllSites = allsites;

                oEvenSitesList.NewEvent = new CEvents();


                return View(oEvenSitesList);
            }
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventsSites oEvenSitesList)
        {
            try
            {
                // TODO: Add insert logic here
                oEvenSitesList.NewEvent.Insert();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                EventsSites eSite = new EventsSites();
                eSite.AllSites = new CSiteList();
                eSite.AllSites.Load();

                CEvents e = new CEvents();
                e.LoadById(id);
                eSite.NewEvent = e;

                return View(eSite);
            }
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventsSites z)
        {
            try
            {
                // TODO: Add update logic here
                z.NewEvent.Update(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                return View();
            }
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Close(int id)
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                o_event = new CEvents();
                o_event.LoadById(id);
                return View(o_event);
            }
        }

        [HttpPost]
        public ActionResult Close(int id, CEvents o_event)
        {
            try
            {
                o_event.CloseEvent();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            
        }
    }
}
