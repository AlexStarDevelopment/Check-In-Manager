using CheckInManager.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInManager.BL
{
    public class CGuest
    {
        //props
        public int GuestID { get; set; }
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public string City { get; set; }
        public string Ethnicity { get; set; }
        public byte RepeatVisitor { get; set; }
        public int EventID { get; set; }

     
        

        //constructors
        public CGuest()
        {
        }
        
        //purpose: adding a guest
        //public CGuest(string gender, string agegroup, string city, string ethnicity, byte repeat)
        //{

        //    Gender = gender;
        //    AgeGroup = agegroup;
        //    City = city;
        //    Ethnicity = ethnicity;
        //    RepeatVisitor = repeat;
          

        //}

        ////purpose: adding a guest
        //public CGuest(string gender, string agegroup, string city, string ethnicity, byte repeat, int eventid)
        //{

        //    Gender = gender;
        //    AgeGroup = agegroup;
        //    City = city;
        //    Ethnicity = ethnicity;
        //    RepeatVisitor = repeat;
        //    EventID = eventid;

        //}

        public CGuest(int guestid, string gender, string agegroup, string city, string ethnicity, byte repeat, int eventId)
        {
            GuestID = guestid;
            Gender = gender;
            AgeGroup = agegroup;
            City = city;
            Ethnicity = ethnicity;
            RepeatVisitor = repeat;
            EventID = eventId;
        }

        //public CGuest(int guestID, string gender, string ageGroup, string city, string ethnicity, int eventID)
        //{
        //    GuestID = guestID;
        //    Gender = gender;
        //    AgeGroup = ageGroup;
        //    City = city;
        //    Ethnicity = ethnicity;
        //    EventID = eventID;
        //}

        //methods
        public bool Insert()
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                tblGuest t_guest = new tblGuest();

                t_guest.GuestID = 1;

                // automatically calculate the new GuestID
                if (oDc.tblGuests.Count() > 0)
                    t_guest.GuestID = oDc.tblGuests.Max(p => p.GuestID) + 1;

                // fill in the data
                this.GuestID = t_guest.GuestID;

                t_guest.Gender = this.Gender;
                t_guest.AgeGroup = this.AgeGroup;
                t_guest.City = this.City;
                t_guest.Ethnicity = this.Ethnicity;
                t_guest.RepeatVisitor = this.RepeatVisitor;
                t_guest.EventID = this.EventID;

                oDc.tblGuests.Add(t_guest);

                oDc.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void LoadByID(int id)
        {
            this.GuestID = id;
            LoadByID();
        }

        public void LoadByID()
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                var otblGuest = oDc.tblGuests.Where(g => g.GuestID == this.GuestID).FirstOrDefault();

                if (otblGuest != null)
                {
                    this.Gender = otblGuest.Gender;
                    this.AgeGroup = otblGuest.AgeGroup;
                    this.Ethnicity = otblGuest.Ethnicity;
                    this.City = otblGuest.City;
                    this.RepeatVisitor = (byte)otblGuest.RepeatVisitor;
                }
                else
                {
                    throw new Exception("Customer was not found.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }


        public void Update()
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                var item = (from p in oDc.tblGuests
                            where p.EventID == this.EventID
                            select p).FirstOrDefault();

                if (item != null)
                {
                    item.GuestID = this.GuestID;
                    item.Gender = this.Gender;
                    item.AgeGroup = this.AgeGroup;
                    item.City = this.City;
                    item.Ethnicity = this.Ethnicity;
                    item.RepeatVisitor = this.RepeatVisitor;
                    item.EventID = this.EventID;
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    

    }

   public class CGuestList:List<CGuest>
    {
        public void Load()
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();

            var guests = (from g in oDc.tblGuests
                          select new
                          {
                              g.GuestID,
                              g.Gender,
                              g.AgeGroup,
                              g.Ethnicity,
                              g.City,
                              g.RepeatVisitor,
                              g.EventID
                          }).ToList();

            foreach(var guest in guests)
            {
                CGuest oGuest = new CGuest();

                oGuest.GuestID = guest.GuestID;
                oGuest.Gender = guest.Gender;
                oGuest.AgeGroup = guest.AgeGroup;
                oGuest.Ethnicity = guest.Ethnicity;
                oGuest.City = guest.City;
                oGuest.RepeatVisitor = (byte)guest.RepeatVisitor;
                oGuest.GuestID = guest.GuestID;
            }


        }


        public CGuestList(int eventID) { }

        public CGuestList() { }

        public void LoadbyEventID(int eventid)
        {
            LFGuestSystemEntities db = new LFGuestSystemEntities();

            var lbd = (from g in db.tblGuests
                       where g.EventID == eventid
                       select new
                       {
                           GuestID = g.GuestID,
                           Gender = g.Gender,
                           AgeGroup = g.AgeGroup,
                           City = g.City,
                           Ethnicity = g.Ethnicity,
                           RepeatVisitor = g.RepeatVisitor,
                           EventID = g.EventID
                       }
                       ).ToList();
            foreach (var g in lbd)
            {
                CGuest guest = new CGuest(g.GuestID, g.Gender, g.AgeGroup, g.City, g.Ethnicity, (byte)g.RepeatVisitor, g.EventID);
                Add(guest);
            }
        }

    }
}
