using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInManager.BL;

namespace CheckInManager.UI.ASP.Controllers
{
    public class SiteController : Controller
    {

        CSite o_site;
        CSiteList o_sites;

        // GET: Site
        public ActionResult Index()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                o_sites = new CSiteList();
                o_sites.Load();
                ViewBag.Message = "All Active Sites";
                return View(o_sites);
            }
            
        }

        // GET: Site/Details/5
        public ActionResult Details(int id)
        {
            o_site = new CSite();
            o_site.LoadById(id);
            return View(o_site);
        }

        // GET: Site/Create
        public ActionResult Create()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                o_site = new CSite();
                return View(o_site);
            }
        }

        // POST: Site/Create
        [HttpPost]
        public ActionResult Create(CSite o_site)
        {
            try
            {
                // TODO: Add insert logic here
                o_site.Insert();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Site/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                o_site = new CSite();
                o_site.LoadById(id);
                return View(o_site);
            }
        }

        // POST: Site/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CSite o_site)
        {
            try
            {
                // TODO: Add update logic here
                o_site.Update(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Site/Delete/5
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

        // POST: Site/Delete/5
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
    }
}
