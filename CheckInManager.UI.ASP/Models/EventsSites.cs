using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckInManager.BL;

namespace CheckInManager.UI.ASP.Models
{
    public class EventsSites
    {

        public CEvents NewEvent { get; set; }
        public CSiteList AllSites { get; set; }

    }
}