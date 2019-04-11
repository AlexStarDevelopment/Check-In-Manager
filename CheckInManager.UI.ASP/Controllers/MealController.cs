using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInManager.BL;

namespace CheckInManager.UI.ASP.Controllers
{
  

    public class MealController : Controller
    {
        CEvents t_event;
        CEventList eventlist;

        // GET: Meal
        public ActionResult Index()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        // GET: Meal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Meal/Create
        public ActionResult Create()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                eventlist = new CEventList();
                eventlist.Load();
                return View(t_event);
            }
            
        }

        // POST: Meal/Create
        [HttpPost]
        public ActionResult Create(CEvents t_event)
        {
            try
            {
                
                // TODO: Add insert logic here
                t_event.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Meal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Meal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Meal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Meal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
