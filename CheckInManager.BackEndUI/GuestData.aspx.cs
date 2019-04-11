using CheckInManager.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckInManager.BackEndUI
{
    
    public partial class GuestData : System.Web.UI.Page
    {
        string gender = "Unknown";
        string age = "Unknown";
        string city = "Other";
        string ethnicity = "Unspecified";
        bool repeat = false;
        int eventID = 1;
        string weather = "clear";
        decimal tempF = 24.2m;
        int siteID = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                CGuest guest = new CGuest();
                guest.Gender = gender;
                guest.AgeGroup = age;
                guest.City = city;
                guest.Ethnicity = ethnicity;
                guest.Repeat = repeat;
                guest.EventID = eventID;
                guest.Insert();

            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void btnNeenah_Click(object sender, EventArgs e)
        {
            btnNeenah.Style.Add(HtmlTextWriterStyle.Color, "blue");
            city = "Neenah";
        }

        protected void btnLtChute_Click(object sender, EventArgs e)
        {
            btnLtChute.Style.Add(HtmlTextWriterStyle.Color, "blue");
            city = "LtChute";
        }

        protected void btnKaukauna_Click(object sender, EventArgs e)
        {
            btnKaukauna.Style.Add(HtmlTextWriterStyle.Color, "blue");
            city = "Kaukauna";
        }

        protected void btnKimberly_Click(object sender, EventArgs e)
        {
            btnKimberly.Style.Add(HtmlTextWriterStyle.Color, "blue");
            city = "Kimberly";
        }

        protected void btnMenasha_Click(object sender, EventArgs e)
        {
            btnKaukauna.Style.Add(HtmlTextWriterStyle.Color, "blue");
            city = "Kaukauna";
        }

        protected void btnAppleton_Click(object sender, EventArgs e)
        {
            btnAppleton.Style.Add(HtmlTextWriterStyle.Color, "blue");
            city = "Appleton";
        }

        protected void btnNative_Click(object sender, EventArgs e)
        {
            btnNative.Style.Add(HtmlTextWriterStyle.Color, "blue");
            ethnicity = "Native American";
        }

        protected void btnHisp_Click(object sender, EventArgs e)
        {
            btnHisp.Style.Add(HtmlTextWriterStyle.Color, "blue");
            ethnicity = "Hispanic";
        }

        protected void btnAsAmer_Click(object sender, EventArgs e)
        {
            btnAsAmer.Style.Add(HtmlTextWriterStyle.Color, "blue");
            ethnicity = "Asian American";
        }

        protected void btnAfAmer_Click(object sender, EventArgs e)
        {
            btnAfAmer.Style.Add(HtmlTextWriterStyle.Color, "blue");
            ethnicity = "African American";
        }

        protected void btnWhite_Click(object sender, EventArgs e)
        {
            btnWhite.Style.Add(HtmlTextWriterStyle.Color, "blue");
            ethnicity = "White";
        }

        protected void btnChild_Click(object sender, EventArgs e)
        {
            btnChild.Style.Add(HtmlTextWriterStyle.Color, "blue");
            age = "Child";
        }

        protected void btnSenior_Click(object sender, EventArgs e)
        {
            btnSenior.Style.Add(HtmlTextWriterStyle.Color, "blue");
            age = "Senior";
        }

        protected void btnAdult_Click(object sender, EventArgs e)
        {
            btnAdult.Style.Add(HtmlTextWriterStyle.Color, "blue");
            age = "Adult";
        }

        protected void btnFemale_Click(object sender, EventArgs e)
        {
            btnFemale.Style.Add(HtmlTextWriterStyle.Color, "blue");
            gender = "Female";
        }

        protected void btnMale_Click(object sender, EventArgs e)
        {
            btnMale.Style.Add(HtmlTextWriterStyle.Color, "blue");
            gender = "Male";
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime date = Calendar1.SelectedDate;
            //ToDo: Write a CEvent Function that takes the selected date and checks for an event.
            // If no event is found, make a new one.
            CEvents todaysEvent = new CEvents();
            eventID = todaysEvent.GetEventID(date, siteID);
        }
    }
}