using CheckInManager.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace CheckInManager.BL
{
    public class CHistory
    {
        //Alex S, I am a little confused by this. Maybe someone can help me understand
        // I fixed the insert... Now we can archive an event into HistoricalData.
        // I was still working on loading by date/year... it's incomplete but
        //   will be used in reporting or comparing historical data. Alex K.

        [DisplayName("Record Number")]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Meals { get; set; }
        public int Guests { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
        public int Children { get; set; }
        public int Seniors { get; set; }
        public int NativeAm { get; set; }
        public int Hispanic { get; set; }
        public int AfricanAm { get; set; }
        public int White { get; set; }
        public int AsianAm { get; set; }
        public int Unspecified { get; set; }
        public int Appleton { get; set; }
        public int Menasha { get; set; }
        public int Kimberly { get; set; }
        public int Kaukauna { get; set; }
        public int LtChute { get; set; }
        public int Neenah { get; set; }
        public int Other { get; set; }
        public string Weather { get; set; }
        public int Adult { get; set; }
        [DisplayName("Temp")]
        public decimal Temp_F { get; set; }
        [DisplayName("Event")]
        public int EventID { get; set; }
        [DisplayName("Location")]
        public int SiteID { get; set; }
        public string Comments { get; set; }
        [DisplayName("Repeat Guest")]
        public int RepeatVisitors { get; set; }

        public CHistory() { }
        public CHistory(DateTime date)
        {
            Date = date;
        }

        public CHistory(int id, DateTime date, int meals, int guests)
        {
            Id = id;
            Date = date;
            Meals = meals;
            Guests = guests;
        }

        public CHistory(int id, DateTime? date, int? meals, int? guests, int? male, int? female, int? children, int? seniors, int? nativeAm, int? hispanic, int? africanAm, int? white, int? asianAm, int? unspecified, int? appleton, int? menasha, int? kimberly, int? kaukauna, int? ltChute, int? neenah, int? other, string weather, decimal? tempf, int? adult, int? eventID, int? siteID, string comments, int? repeatVisitors)
        {

            Id = id;
            Date = date ?? DateTime.Now;
            Meals = meals ?? 0;
            Guests = guests ?? 0;
            Male = male ?? 0;
            Female = female ?? 0;
            Children = children ?? 0;
            Seniors = seniors ?? 0;
            NativeAm = nativeAm ?? 0;
            Hispanic = hispanic ?? 0;
            AfricanAm = africanAm ?? 0;
            White = white ?? 0;
            AsianAm = asianAm ?? 0;
            Unspecified = unspecified ?? 0;
            Appleton = appleton ?? 0;
            Menasha = menasha ?? 0;
            Kimberly = kimberly ?? 0;
            Kaukauna = kaukauna ?? 0;
            LtChute = ltChute ?? 0;
            Neenah = neenah ?? 0;
            Other = other ?? 0;
            Weather = weather ?? "Clear";
            Temp_F = tempf ?? 0;
            Adult = adult ?? 0;
            EventID = eventID ?? -1;
            SiteID = siteID ?? 1;
            Comments = comments ?? "No Comment Entered";
            RepeatVisitors = repeatVisitors ?? 0;
        }

        public void Insert(int eventid)
        {
            try
            {
                var eventguests = new CGuestList();
                var eventinfo = new CEvents();

                eventguests.LoadbyEventID(eventid);
                eventinfo.LoadById(eventid);
                
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();
                
                HistoricalData hdEvent = new HistoricalData();
                hdEvent.Id = 1;
                if (oDc.HistoricalDatas.Count() > 0)
                    hdEvent.Id = oDc.HistoricalDatas.Max(p => p.Id) + 1;

                // fill in the data
                this.Id = hdEvent.Id;
                hdEvent.Date = eventinfo.Date;
                hdEvent.Meals = eventinfo.MealCount;
                hdEvent.Guests = eventguests.Count();
                hdEvent.Male = eventguests.Where(g => g.Gender == "Male").Count();
                hdEvent.Female = eventguests.Where(g => g.Gender == "Female").Count();
                hdEvent.Adult = eventguests.Where(a => a.AgeGroup == "Adult").Count(); ;
                hdEvent.Children = eventguests.Where(a => a.AgeGroup == "Child").Count();
                hdEvent.Seniors = eventguests.Where(a => a.AgeGroup == "Senior").Count();
                hdEvent.NativeAm = eventguests.Where(e => e.Ethnicity == "NativeAm").Count();
                hdEvent.AfricanAm = eventguests.Where(e => e.Ethnicity == "AfricanAm").Count();
                hdEvent.White = eventguests.Where(e => e.Ethnicity == "White").Count();
                hdEvent.Hispanic = eventguests.Where(e => e.Ethnicity == "Hispanic").Count();
                hdEvent.AsianAm = eventguests.Where(e => e.Ethnicity == "AsianAm").Count();
                hdEvent.Unspecified = eventguests.Where(e => e.Ethnicity == "Unspecified").Count();
                hdEvent.Appleton = eventguests.Where(c => c.City == "Appleton").Count();
                hdEvent.Menasha = eventguests.Where(c => c.City == "Menasha").Count();
                hdEvent.Kimberly = eventguests.Where(c => c.City == "Kimberly").Count();
                hdEvent.Kaukauna = eventguests.Where(c => c.City == "Kaukauna").Count();
                hdEvent.LtChute = eventguests.Where(c => c.City == "LtChute").Count();
                hdEvent.Neenah = eventguests.Where(c => c.City == "Neenah").Count();
                hdEvent.Other = eventguests.Where(c => c.City == "Other").Count();
                hdEvent.Weather = eventinfo.WeatherDesc;
                
                hdEvent.Temp_F = eventinfo.Temp;
                hdEvent.EventID = eventid;
                hdEvent.SiteID = eventinfo.SiteID;
                hdEvent.Comments = eventinfo.Comments;
                hdEvent.RepeatVisitors = eventguests.Where(r => r.RepeatVisitor == 1).Count();
                oDc.HistoricalDatas.Add(hdEvent);
                oDc.SaveChanges();
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void LoadbyEventID(int eventid)
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();
            var hdEvent = (from hd in oDc.HistoricalDatas
                           where hd.EventID == eventid
                           select new
                           {
                               hd.Id,
                               hd.Date,
                               hd.Meals,
                               hd.Guests,
                           }).FirstOrDefault();
            Id = hdEvent.Id;
            Date = (DateTime)hdEvent.Date;
            Meals = (int)hdEvent.Meals;
            Guests = (int)hdEvent.Guests;
        }

        public void LoadTallyByID(int id)
        {
            LFGuestSystemEntities db = new LFGuestSystemEntities();
            var hist = (from h in db.HistoricalDatas
                        where h.Id == id
                        select h).FirstOrDefault();

            this.Id = hist.Id;
            this.Date = hist.Date ?? DateTime.Now;
            this.Meals = hist.Meals ?? 0;
            this.Guests = hist.Guests ?? 0;
            this.Male = hist.Male ?? 0;
            this.Female = hist.Female ?? 0;
            this.Children = hist.Children ?? 0;
            this.Seniors = hist.Seniors ?? 0;
            this.NativeAm = hist.NativeAm ?? 0;
            this.Hispanic = hist.Hispanic ?? 0;
            this.AfricanAm = hist.AfricanAm ?? 0;
            this.White = hist.White ?? 0;
            this.AsianAm = hist.AsianAm ?? 0;
            this.Unspecified = hist.Unspecified ?? 0;
            this.Appleton = hist.Appleton ?? 0;
            this.Menasha = hist.Menasha ?? 0;
            this.Kimberly = hist.Kimberly ?? 0;
            this.Kaukauna = hist.Kaukauna ?? 0;
            this.LtChute = hist.LtChute ?? 0;
            this.Neenah = hist.Neenah ?? 0;
            this.Other = hist.Other ?? 0;
            this.Weather = hist.Weather;
            this.Adult = hist.Adult ?? 0;
            this.Temp_F = hist.Temp_F ?? 0;
            this.EventID = hist.EventID ?? 0;
            this.SiteID = hist.SiteID ?? 0;
            this.Comments = hist.Comments;
            this.RepeatVisitors = hist.RepeatVisitors ?? 0;

        }


        public void UpdateTally(int id)
        {
            LFGuestSystemEntities db = new LFGuestSystemEntities();
            
            var hist = (from h in db.HistoricalDatas
                        where h.Id == id
                        select h).FirstOrDefault();
            if (hist != null)
            {

                this.Id = this.Id;
                hist.Date = this.Date;
                hist.Meals = this.Meals;
                hist.Guests = this.Guests;
                hist.Male = this.Male;
                hist.Female = this.Female;
                hist.Children = this.Children;
                hist.Seniors = this.Seniors;
                hist.NativeAm = this.NativeAm;
                hist.Hispanic = this.Hispanic;
                hist.AfricanAm = this.AfricanAm;
                hist.White = this.White;
                hist.AsianAm = this.AsianAm;
                hist.Unspecified = this.Unspecified;
                hist.Appleton = this.Appleton;
                hist.Menasha = this.Menasha;
                hist.Kimberly = this.Kimberly;
                hist.Kaukauna = this.Kaukauna;
                hist.LtChute = this.LtChute;
                hist.Neenah = this.Neenah;
                hist.Other = this.Other;
                hist.Weather = this.Weather;
                hist.Adult = this.Adult;
                hist.Temp_F = this.Temp_F;
                hist.EventID = this.EventID;
                hist.SiteID = this.SiteID;
                hist.Comments = this.Comments;
                hist.RepeatVisitors = this.RepeatVisitors;
                db.SaveChanges();
            }

        }

        public void InsertTally()
        {
            try
            {
                LFGuestSystemEntities db = new LFGuestSystemEntities();
                HistoricalData tDat = new HistoricalData();

                tDat.Id = 1;
                if (db.HistoricalDatas.Count() > 0)
                    tDat.Id = db.HistoricalDatas.Max(h => h.Id) + 1;

                this.Id = tDat.Id;
                tDat.Date = this.Date;
                tDat.Meals = this.Meals;
                tDat.Guests = this.Guests;
                tDat.Male = this.Male;
                tDat.Female = this.Female;
                tDat.Children = this.Children;
                tDat.Seniors = this.Seniors;
                tDat.NativeAm = this.NativeAm;
                tDat.Hispanic = this.Hispanic;
                tDat.AfricanAm = this.AfricanAm;
                tDat.White = this.White;
                tDat.AsianAm = this.AsianAm;
                tDat.Unspecified = this.Unspecified;
                tDat.Appleton = this.Appleton;
                tDat.Menasha = this.Menasha;
                tDat.Kimberly = this.Kimberly;
                tDat.Kaukauna = this.Kaukauna;
                tDat.LtChute = this.LtChute;
                tDat.Neenah = this.Neenah;
                tDat.Other = this.Other;
                tDat.Weather = this.Weather ?? "Clear";
                tDat.Adult = this.Adult;
                tDat.Temp_F = this.Temp_F; 
                tDat.EventID = this.EventID;
                tDat.SiteID = this.SiteID;
                tDat.Comments = this.Comments;
                tDat.RepeatVisitors = this.RepeatVisitors;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
         

        }

    }


    public class CHistoryList : List<CHistory>
    {
        public void Load()
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();
            try
            {
                var ohd = (from hds in oDc.HistoricalDatas
                           orderby hds.Date
                           select new
                           {
                               hds.Id,
                               hds.Date,
                               hds.Meals,
                               hds.Guests,
                               hds.Male,
                               hds.Female,
                               hds.Children,
                               hds.Seniors,
                               hds.NativeAm,
                               hds.Hispanic,
                               hds.AfricanAm,
                               hds.White,
                               hds.AsianAm,
                               hds.Unspecified,
                               hds.Appleton,
                               hds.Menasha,
                               hds.Kimberly,
                               hds.Kaukauna,
                               hds.LtChute,
                               hds.Neenah,
                               hds.Other,
                               hds.Weather,
                               hds.Temp_F,
                               hds.Adult,
                               hds.EventID,
                               hds.SiteID,
                               hds.Comments,
                               hds.RepeatVisitors
                           }
                           ).ToList();
                foreach (var hd in ohd)
                {
                    CHistory t_history = new CHistory(hd.Id, hd.Date, hd.Meals, hd.Guests, hd.Male, hd.Female, hd.Children, hd.Seniors, hd.NativeAm, hd.Hispanic, hd.AfricanAm, hd.White, hd.AsianAm, hd.Unspecified, hd.Appleton, hd.Menasha, hd.Kimberly, hd.Kaukauna, hd.LtChute,
                               hd.Neenah, hd.Other, hd.Weather, hd.Temp_F, hd.Adult, hd.EventID, hd.SiteID, hd.Comments, hd.RepeatVisitors);
                    Add(t_history);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void LoadJustTallies()
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();
            try
            {
                var ohd = (from hds in oDc.HistoricalDatas
                           where hds.Comments == "Tallied Meal"
                           orderby hds.Date
                           select new
                           {
                               hds.Id,
                               hds.Date,
                               hds.Meals,
                               hds.Guests,
                               hds.Male,
                               hds.Female,
                               hds.Children,
                               hds.Seniors,
                               hds.NativeAm,
                               hds.Hispanic,
                               hds.AfricanAm,
                               hds.White,
                               hds.AsianAm,
                               hds.Unspecified,
                               hds.Appleton,
                               hds.Menasha,
                               hds.Kimberly,
                               hds.Kaukauna,
                               hds.LtChute,
                               hds.Neenah,
                               hds.Other,
                               hds.Weather,
                               hds.Temp_F,
                               hds.Adult,
                               hds.EventID,
                               hds.SiteID,
                               hds.Comments,
                               hds.RepeatVisitors
                           }
                           ).ToList();
                foreach (var hd in ohd)
                {
                    CHistory t_history = new CHistory(hd.Id, hd.Date, hd.Meals, hd.Guests, hd.Male, hd.Female, hd.Children, hd.Seniors, hd.NativeAm, hd.Hispanic, hd.AfricanAm, hd.White, hd.AsianAm, hd.Unspecified, hd.Appleton, hd.Menasha, hd.Kimberly, hd.Kaukauna, hd.LtChute,
                               hd.Neenah, hd.Other, hd.Weather, hd.Temp_F, hd.Adult, hd.EventID, hd.SiteID, hd.Comments, hd.RepeatVisitors);
                    Add(t_history);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void LoadByRange(int siteid, DateTime startdate, DateTime enddate)
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();
            try
            {
                var ohd = (from hds in oDc.HistoricalDatas
                           where (hds.Date > startdate && hds.Date < enddate) && hds.SiteID == siteid
                           orderby hds.Date
                           select new
                           {
                               hds.Id,
                               hds.Date,
                               hds.Meals,
                               hds.Guests,
                               hds.Male,
                               hds.Female,
                               hds.Children,
                               hds.Seniors,
                               hds.NativeAm,
                               hds.AfricanAm,
                               hds.White,
                               hds.AsianAm,
                               hds.Unspecified,
                               hds.Appleton,
                               hds.Menasha,
                               hds.Kimberly,
                               hds.Kaukauna,
                               hds.LtChute,
                               hds.Neenah,
                               hds.Other,
                               hds.Weather,
                               hds.Temp_F,
                               hds.Adult,
                               hds.EventID,
                               hds.SiteID,
                               hds.Comments,
                               hds.RepeatVisitors
                           }
                           ).ToList();
                foreach(var hd in ohd)
                {
                    CHistory th = new CHistory();
                    th.Id = hd.Id;
                    th.Date = hd.Date ?? DateTime.Now;
                    th.Meals = hd.Meals ?? 0;
                    th.Guests = hd.Guests ?? 0;
                    th.Male = hd.Male ?? 0;
                    th.Female = hd.Female ?? 0;
                    th.Children = hd.Children ?? 0;
                    th.Seniors = hd.Seniors ?? 0;
                    th.NativeAm = hd.NativeAm ?? 0;
                    th.AfricanAm = hd.AfricanAm ?? 0;
                    th.White = hd.White ?? 0;
                    th.AsianAm = hd.AsianAm ?? 0;
                    th.Unspecified = hd.Unspecified ?? 0;
                    th.Appleton = hd.Appleton ?? 0;
                    th.Menasha = hd.Menasha ?? 0;
                    th.Kimberly = hd.Kimberly ?? 0;
                    th.Kaukauna = hd.Kaukauna ?? 0;
                    th.LtChute = hd.LtChute ?? 0;
                    th.Neenah = hd.Neenah ?? 0;
                    th.Other = hd.Other ?? 0;
                    th.Weather = hd.Weather ?? "Clear";
                    th.Temp_F = hd.Temp_F ?? 54.0m;
                    th.Adult = hd.Adult ?? 0;
                    th.EventID = hd.EventID ?? -1;
                    th.SiteID = hd.SiteID ?? 1;
                    th.Comments = hd.Comments;
                    th.RepeatVisitors = hd.RepeatVisitors ?? 0;
                    Add(th);
                }
                           
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        



    }

    public class CAnualNumbersList : List<CHistory>
    {
        public void Load()
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();
            DateTime today = DateTime.Today;
            DateTime date;
            
            //DateTime oneyear = (today.AddDays(-1)).AddYears(-1);
            //DateTime twoyear = (today.AddDays(-2)).AddYears(-2);
            //DateTime threeyear = (today.AddDays(-3)).AddYears(-3);

            // ***NOT COMPLETED CODE***
            for (int y = 1; y < 4; y++)
            {
                date = (today.AddDays(-y)).AddYears(-y);
                var anualnums = (from hd in oDc.HistoricalDatas
                                                where hd.Date == date
                                                orderby hd.Date
                                                select new
                                                {
                                                    hd.Id,
                                                    hd.Date,
                                                    hd.Meals,
                                                    hd.Guests,
                                                }).ToList();
            }

            //foreach(var anualnum in anualnums)
            //{
            //    CHistory oHistory = new CHistory();
            //    oHistory.Id = anualnum.Id;
            //    oHistory.Date = anualnum.Date;
            //    oHistory.Meals = anualnum.Meals;
            //    oHistory.Guests = anualnum.Guests;
            //    this.Add(oHistory);
            //}


        }
    }
}
