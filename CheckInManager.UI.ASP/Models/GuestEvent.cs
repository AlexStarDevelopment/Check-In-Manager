using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckInManager.BL;

namespace CheckInManager.UI.ASP.Models
{
    public class GuestEvent
    {
        public CGuest Guest { get; set; }
        public CEvents Events { get; set; }
    }
}