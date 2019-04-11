using System;
using System.Text;
using System.Collections.Generic;
using CheckInManager.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CheckInManager.BL.Test
{
    [TestClass]
    public class utGuest
    {
        [TestMethod]
        public void Insert()
        {
            CGuest oGuest = new CGuest();
            oGuest.Gender = "female";
            oGuest.AgeGroup = "child";
            oGuest.Ethnicity = "white";
            oGuest.City = "appleton";
            oGuest.RepeatVisitor = 0;

            oGuest.Insert();

            CGuest oNewGuest = new CGuest();
            oNewGuest.GuestID = oGuest.GuestID;
            oNewGuest.LoadByID();

            Assert.AreEqual(oGuest.City, oNewGuest.City);
        }
    }
}
