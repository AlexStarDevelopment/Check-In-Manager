using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using CheckInManager.BL;
using OfficeOpenXml;
using CheckInManager.UI.ASP.Models;

namespace CheckInManager.UI.ASP.Controllers
{
    public class HistoryController : Controller
    {
        
        CHistoryList o_historylist;
        
        // GET: History
        public ActionResult Index()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                try
                {
                    SelectRange datasource = new SelectRange();
                    datasource.ListofSites = new CSiteList();
                    datasource.ListofSites.Load();
                    return View(datasource);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
                
            }
            
        }

        public ActionResult DataExport(int siteid, DateTime startdate, DateTime enddate)
        {
            if(startdate == null || enddate == null)
            {
                return View();
            }
            else
            {
                try
                {
                    Session["startdate"] = startdate;
                    Session["enddate"] = enddate;
                    Session["siteid"] = siteid;
                    o_historylist = new CHistoryList();
                    o_historylist.LoadByRange(siteid, startdate, enddate);
                    ViewBag.Message = "All Historical Events";
                    return View(o_historylist);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            return File(Encoding.ASCII.GetBytes(GridHtml), "application/vnd.ms-excel", "History.xls");
        }

        public void ExporttoExcel()
        {
            DateTime startdate = (DateTime)Session["startdate"];
            DateTime enddate = (DateTime)Session["enddate"];
            int siteid = (int)Session["siteid"];

            CHistoryList hlist = new CHistoryList();
            hlist.LoadByRange(siteid, startdate, enddate);

            ExcelPackage pkg = new ExcelPackage();
            ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Communication";
            ws.Cells["B1"].Value = "Com1";

            ws.Cells["A2"].Value = "Report";
            ws.Cells["B2"].Value = "Report1";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}",DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Id";
            ws.Cells["B6"].Value = "Date";
            ws.Cells["C6"].Value = "Meals";
            ws.Cells["D6"].Value = "Guests";
            ws.Cells["E6"].Value = "Male";
            ws.Cells["F6"].Value = "Female";
            ws.Cells["G6"].Value = "Adult";
            ws.Cells["H6"].Value = "Children";
            ws.Cells["I6"].Value = "Seniors";
            ws.Cells["J6"].Value = "NativeAm";
            ws.Cells["K6"].Value = "AfricanAm";
            ws.Cells["L6"].Value = "White";
            ws.Cells["M6"].Value = "AsianAm";
            ws.Cells["N6"].Value = "Unspecified";
            ws.Cells["O6"].Value = "Appleton";
            ws.Cells["P6"].Value = "Menasha";
            ws.Cells["Q6"].Value = "Kimberly";
            ws.Cells["R6"].Value = "Kaukauna";
            ws.Cells["S6"].Value = "LtChute";
            ws.Cells["T6"].Value = "Neenah";
            ws.Cells["U6"].Value = "Other";
            ws.Cells["V6"].Value = "Weather";
            ws.Cells["W6"].Value = "Temp_F";
            ws.Cells["X6"].Value = "EventID";
            ws.Cells["Y6"].Value = "SiteID";
            ws.Cells["Z6"].Value = "Comments";
            ws.Cells["AA6"].Value = "RepeatVisitors";

            int rowStart = 7;
            foreach(var item in hlist)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Date.ToString("g");
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Meals;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Guests;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Male;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Female;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Adult;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Children;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Seniors;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.NativeAm;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.AfricanAm;
                ws.Cells[string.Format("L{0}", rowStart)].Value = item.White;
                ws.Cells[string.Format("M{0}", rowStart)].Value = item.AsianAm;
                ws.Cells[string.Format("N{0}", rowStart)].Value = item.Unspecified;
                ws.Cells[string.Format("O{0}", rowStart)].Value = item.Appleton;
                ws.Cells[string.Format("P{0}", rowStart)].Value = item.Menasha;
                ws.Cells[string.Format("Q{0}", rowStart)].Value = item.Kimberly;
                ws.Cells[string.Format("R{0}", rowStart)].Value = item.Kaukauna;
                ws.Cells[string.Format("S{0}", rowStart)].Value = item.LtChute;
                ws.Cells[string.Format("T{0}", rowStart)].Value = item.Neenah;
                ws.Cells[string.Format("U{0}", rowStart)].Value = item.Other;
                ws.Cells[string.Format("V{0}", rowStart)].Value = item.Weather;
                ws.Cells[string.Format("W{0}", rowStart)].Value = item.Temp_F;
                ws.Cells[string.Format("X{0}", rowStart)].Value = item.EventID;
                ws.Cells[string.Format("Y{0}", rowStart)].Value = item.SiteID;
                ws.Cells[string.Format("Z{0}", rowStart)].Value = item.Comments;
                ws.Cells[string.Format("AA{0}", rowStart)].Value = item.RepeatVisitors;
                
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pkg.GetAsByteArray());
            Response.End();
            //Session["startdate"] = null;
            //Session["enddate"] = null;

        }

        // GET: History/CreateTally
        public ActionResult CreateTally()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                CHistory newHist = new CHistory();

                return View(newHist);
            }
        }

        // POST: History/CreateTally
        [HttpPost]
        public ActionResult CreateTally(CHistory newHist)
        {
            try
            {
                // TODO: Add insert logic here
                newHist.InsertTally();
                return RedirectToAction("HistoryList", "History");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult HistoryList()
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                CHistoryList histories = new CHistoryList();
                histories.LoadJustTallies();
                ViewBag.Message = "All History Data";
                return View(histories);
            }

        }

        public ActionResult EditTally(int id)
        {
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
            else
            {
                CHistory newHist = new CHistory();
                newHist.LoadTallyByID(id);
                return View(newHist);
            }
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult EditTally(int id, CHistory newHist)
        {
            try
            {
                // TODO: Add update logic here
                newHist.UpdateTally(id);
                return RedirectToAction("HistoryList");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }


    }

    
}