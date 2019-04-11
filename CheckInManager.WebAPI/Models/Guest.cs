using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckInManager.WebAPI.Models
{
    public class Guest
    {
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public string City { get; set; }
        public string Ethnicity { get; set; }
        public bool Repeat { get; set; }
        public int EventID { get; set; }

    }
}