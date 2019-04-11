using CheckInManager.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Dynamic;
using System.Net;

//this needs updating for the new props


namespace CheckInManager.BL
{
    public class CEvents
    {
        //props
        [DisplayName("Event")]
        public int EventID { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Meal Count")]
        public int MealCount { get; set; }
        [DisplayName("Volunteers")]
        public int VolunteerCount { get; set; }
        [DisplayName("Location")]
        public string SiteName { get; set; }
        public int SiteID { get; set; }
        [DisplayName("Weather")]
        public string WeatherDesc { get; set; }
        [DisplayName("Temperature")]
        public decimal Temp { get; set; }
        [DisplayName("Child Tray")]
        public int ChildTray { get; set; }
        [DisplayName("Adult Tray")]
        public int AdultTray { get; set; }
        [DisplayName("Employee is Active")]
        public bool isActive { get; set; }
        public string Comments { get; set; }

        //constructors
        public CEvents()
        {
        }

        public CEvents(int siteid)
        {
            SiteID = siteid;
        }

        public CEvents(int eventid, DateTime date, int mealcount, int volunteercount, int siteid, string weatherDesc, decimal temp, int childtray, int adultTray)
        {
            EventID = eventid;
            Date = date;
            MealCount = mealcount;
            VolunteerCount = volunteercount;
            SiteID = siteid;
            WeatherDesc = weatherDesc;
            Temp = temp;
            ChildTray = childtray;
            AdultTray = adultTray;
        }

        public CEvents(int eventid, DateTime date, int mealcount, int volunteercount, int siteid, string weatherDesc, decimal temp, int childtray, int adultTray, bool isactive)
        {
            EventID = eventid;
            Date = date;
            MealCount = mealcount;
            VolunteerCount = volunteercount;
            SiteID = siteid;
            WeatherDesc = weatherDesc;
            Temp = temp;
            ChildTray = childtray;
            AdultTray = adultTray;
            isActive = isactive;
        }

        public CEvents(int eventID, DateTime date, int mealCount, int volunteerCount, int siteID, string weatherDesc, decimal temp, int childTray, int adultTray, string comments)
        {
            EventID = eventID;
            Date = date;
            MealCount = mealCount;
            VolunteerCount = volunteerCount;
            SiteID = siteID;
            WeatherDesc = weatherDesc;
            Temp = temp;
            ChildTray = childTray;
            AdultTray = adultTray;
            Comments = comments;
        }

        public CEvents(int eventid, DateTime date, int mealcount, int volunteercount, int siteid, string weatherDesc, decimal temp, int childtray, int adultTray, bool isactive, string comments)
        {
            EventID = eventid;
            Date = date;
            MealCount = mealcount;
            VolunteerCount = volunteercount;
            SiteID = siteid;
            WeatherDesc = weatherDesc;
            Temp = temp;
            ChildTray = childtray;
            AdultTray = adultTray;
            isActive = isactive;
            Comments = comments;
        }
                        
        

        public CEvents(int eventid, DateTime date, string sitename, int mealcount, int volunteercount, int siteid, string weatherDesc, decimal temp, int childtray, int adultTray, bool isactive, string comments)
        {
            EventID = eventid;
            Date = date;
            MealCount = mealcount;
            VolunteerCount = volunteercount;
            SiteName = sitename;
            SiteID = siteid;
            WeatherDesc = weatherDesc;
            Temp = temp;
            ChildTray = childtray;
            AdultTray = adultTray;
            isActive = isactive;
            Comments = comments;
        }

        

        public CEvents(int eventid, DateTime date, string siteName, int mealcount, int volunteercount, int siteid, string weatherDesc, decimal temp, int childtray, int adultTray, string comments) : this(eventid, date, mealcount, volunteercount, siteid, weatherDesc, temp, childtray, adultTray)
        {
            Comments = comments;
        }

        //methods
        public void Insert()
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();
                tblEvent t_event = new tblEvent();
                t_event.EventID = 1;
                // automatically calculate the new tblEventID
                if (oDc.tblEvents.Count() > 0)
                    t_event.EventID = oDc.tblEvents.Max(p => p.EventID) + 1;

                // fill in the data
                this.EventID = t_event.EventID;
                t_event.Date = this.Date;
                t_event.MealCount = 0;
                t_event.VolunteerCount = 0;
                t_event.SiteID = this.SiteID;
                t_event.WeatherDesc = "Clear";
                t_event.Temp = 50.0m;
                t_event.ChildTray = 0;
                t_event.AdultTray = 0;
                t_event.IsActive = true;
                t_event.Comments = this.Comments;
                oDc.tblEvents.Add(t_event);
                oDc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }   

        }

        public void LoadById(int eventid)
        {
            LFGuestSystemEntities db = new LFGuestSystemEntities();

            var d = (from p in db.tblEvents
                     join s in db.tblSites on p.SiteID equals s.SiteID
                     where p.EventID == eventid
                     orderby p.EventID
                     select new
                     {
                         p.EventID,
                         p.Date,
                         p.MealCount,
                         p.VolunteerCount,
                         s.SiteName,
                         p.SiteID,
                         p.WeatherDesc,
                         p.Temp,
                         p.ChildTray,
                         p.AdultTray,
                         p.Comments
                     }).FirstOrDefault();

            this.EventID = d.EventID;
            this.Date = d.Date;
            this.MealCount = d.MealCount ?? 0;
            this.VolunteerCount = d.VolunteerCount ?? 0; 
            this.SiteName = d.SiteName;
            this.SiteID = d.SiteID;
            this.WeatherDesc = d.WeatherDesc;
            this.Temp = d.Temp ?? 54.0m;
            this.ChildTray = d.ChildTray ?? 0;
            this.AdultTray = d.AdultTray ?? 0;
            this.Comments = d.Comments;
        }

        public void Update(int id)
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                 var item = (from p in oDc.tblEvents
                            where p.EventID == id
                            select p).FirstOrDefault();

                if (item != null)
                {
                    this.EventID = this.EventID;
                    item.Date = this.Date;
                    item.MealCount = this.ChildTray + this.AdultTray;
                    item.VolunteerCount = this.VolunteerCount;
                    item.SiteID = this.SiteID;
                    item.WeatherDesc = this.WeatherDesc;
                    item.Temp = this.Temp;
                    item.ChildTray = this.ChildTray;
                    item.AdultTray = this.AdultTray;
                    item.Comments = this.Comments;
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
             throw ex;
            }
        }
        public void CloseEvent()
        {
            CWeather CurrentWeather = new CWeather();
           // dynamic CurrentWeather;
            try
            {
                using (var wc = new WebClient())
                {
                    var jsonString = "http://api.wunderground.com/api/37f4201157f6db0a/conditions/q/WI/Appleton.json";

                    string rawJSON = wc.DownloadString(jsonString);
                    CurrentWeather = JsonConvert.DeserializeObject<CWeather>(rawJSON);
                }
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                var item = (from p in oDc.tblEvents
                            where p.EventID == this.EventID
                            select p).FirstOrDefault();

                if (item != null)
                {
                    //item.EventID = this.EventID;
                    //item.Date = this.Date;
                    item.MealCount = this.ChildTray + this.AdultTray;
                    item.VolunteerCount = this.VolunteerCount;
                    //item.SiteID = this.SiteID;
                    item.Temp = Convert.ToDecimal(CurrentWeather.CurrentObservation.TempF);
                    item.WeatherDesc = CurrentWeather.CurrentObservation.Weather;
                    item.ChildTray = this.ChildTray;
                    item.AdultTray = this.AdultTray;
                    item.IsActive = false;
                    item.Comments = this.Comments;
                    oDc.SaveChanges();
                }

                CHistory archive = new CHistory();
                archive.Insert(EventID);
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public int GetEventID(DateTime date, int site)
        {
            this.Date = date;
            this.SiteID = site;
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();
                tblEvent t_event = oDc.tblEvents.Where(p => (p.Date == this.Date && p.SiteID == this.SiteID)).FirstOrDefault();

                if(t_event == null)
                { Insert();
                }

                return this.EventID;
            }

            catch (Exception ex)
            {
                throw ex;  
            }
            
        }

       

    }

    public class CEventList:List<CEvents>
    {
        public CEventList() { }
        public CEventList(DateTime date) { }

        public void Load()
        {
            LFGuestSystemEntities db = new LFGuestSystemEntities();

            var ebd = (from e in db.tblEvents
                       join s in db.tblSites on e.SiteID equals s.SiteID
                       where e.IsActive == true
                       orderby e.Date
                       select new
                       {
                           e.EventID,
                           e.Date,
                           s.SiteName,
                           e.MealCount,
                           e.VolunteerCount,
                           e.SiteID,
                           e.WeatherDesc,
                           e.Temp,
                           e.ChildTray,
                           e.AdultTray,
                           e.IsActive,
                           e.Comments
                       }
                       ).ToList();

            foreach (var ev in ebd)
            {
                CEvents es = new CEvents();
                es.EventID = ev.EventID;
                es.Date = ev.Date;
                es.SiteName = ev.SiteName;
                es.MealCount = ev.MealCount ?? 0;
                es.VolunteerCount = ev.VolunteerCount ?? 0;
                es.SiteID = ev.SiteID;
                es.WeatherDesc = ev.WeatherDesc;
                es.Temp = ev.Temp ?? 54.0m;
                es.ChildTray = ev.ChildTray ?? 0;
                es.AdultTray = ev.AdultTray ?? 0;
                es.isActive = ev.IsActive ?? true;
                es.Comments = ev.Comments;
   
                Add(es);
            }

        }

        public void LoadbyDate(DateTime date)
        {
            LFGuestSystemEntities db = new LFGuestSystemEntities();


            var ebd = (from e in db.tblEvents
                       join s in db.tblSites on e.SiteID equals s.SiteID
                       where e.Date == date && e.IsActive == true
                       orderby e.Date
                       select new
                       {
                           e.EventID,
                           e.Date,
                           s.SiteName,
                           e.MealCount,
                           e.VolunteerCount,
                           e.SiteID,
                           e.WeatherDesc,
                           e.Temp,
                           e.ChildTray,
                           e.AdultTray,
                           e.IsActive,
                           e.Comments
                       }
                       ).ToList();

            foreach (var ev in ebd)
            {
                CEvents t_event = new CEvents(ev.EventID, ev.Date, ev.SiteName, (int)ev.MealCount, (int)ev.VolunteerCount, ev.SiteID, ev.WeatherDesc, (decimal)ev.Temp, (int)ev.ChildTray, (int)ev.AdultTray, ev.Comments);
                Add(t_event);
            }

        }

        private void GetWeather()
        {

            // Junk that did not work...
            //var jsonString = "http://api.wunderground.com/api/37f4201157f6db0a/conditions/q/WI/Appleton.json";
            //var CurrentWeather = CWeather.FromJson(jsonString);

            //var json = JsonConvert.DeserializeObject(jsonlink);

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //dynamic CurrentWeather = JsonConvert.DeserializeObject(json);
            var jsonlink = "http://api.wunderground.com/api/37f4201157f6db0a/conditions/q/WI/Appleton.json";
            //var webClient = new WebClient())
            dynamic CurrentWeather = JsonConvert.DeserializeObject(jsonlink);

        }

    }
}
