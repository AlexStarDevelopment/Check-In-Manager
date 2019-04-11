using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInManager.CP.Model
{
    public class Meal
    {
        public int EventID { get; set; }
        public DateTime Date { get; set; }
        public string SiteName { get; set; }
        public int MealCount { get; set; }
        public int VolunteerCount { get; set; }
        public int SiteID { get; set; }
        public int ChildTray { get; set; }
        public int AdultTray { get; set; }
    }
}
