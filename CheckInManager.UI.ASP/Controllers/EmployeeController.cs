using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInManager.BL;
using CheckInManager.UI.ASP.Models;

namespace CheckInManager.UI.ASP.Controllers
{
    public class EmployeeController : Controller
    {
        CEmployeesList emps;
        CEmployees emp;
        // GET: Employee
        public ActionResult Index()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                emps = new CEmployeesList();
                emps.Load();
                ViewBag.Message = "All Declarations";
                return View(emps);
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            emp = new CEmployees();
            emp.LoadById(id);
            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                EmployeeRole eRole = new EmployeeRole();

                CRoleList roles = new CRoleList();
                roles.Load();

                eRole.NewRole = roles;

                eRole.NewEmployee = new CEmployees();


                return View(eRole);
            }
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeRole e)
        {
            try
            {
                // TODO: Add insert logic here
                e.NewEmployee.Insert();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                EmployeeRole eRole = new EmployeeRole();
                eRole.NewRole = new CRoleList();
                eRole.NewRole.Load();

                CEmployees e = new CEmployees();
                e.LoadById(id);
                eRole.NewEmployee = e;

                return View(eRole);
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeRole e)
        {
            try
            {
                // TODO: Add update logic here
                e.NewEmployee.Update(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                emp = new CEmployees();
                emp.LoadById(id);
                return View(emp);
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CEmployees c)
        {
            try
            {
                // TODO: Add delete logic here
                c.Delete(id);
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
