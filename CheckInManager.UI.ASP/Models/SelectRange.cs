using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CheckInManager.BL;

namespace CheckInManager.UI.ASP.Models
{
    public class SelectRange
    {
        [DisplayName("Beginning Date:")]
        [DataType(DataType.Date), Required]
        public DateTime StartDate {get;set;}
        [DisplayName("Ending Date:")]
        [DataType(DataType.Date), Required]
        public DateTime EndDate { get; set; }
        [DisplayName("Site:")]
        public int SiteID { get; set; }

        public CSiteList ListofSites { get; set;}
    }
}