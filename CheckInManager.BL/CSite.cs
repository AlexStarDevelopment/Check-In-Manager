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
    public class CSite
    {
        //props
        [DisplayName("Location")]
        public int SiteID { get; set; }
        [DisplayName("Location")]
        public string SiteName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        //constructors
        public CSite() { }

        public CSite(int siteid, string sitename)
        {
            SiteID = siteid;
            SiteName = sitename;
        }

        public CSite(int siteid, string sitename, string street, string city, string state, string zipcode)
        {
            SiteID = siteid;
            SiteName = sitename;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipcode;            
        }

        //methods
        public void Insert()
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();
                tblSite t_site = new tblSite();
                t_site.SiteID = 1;
                // automatically calculate the new siteID
                if (oDc.tblSites.Count() > 0)
                    t_site.SiteID = oDc.tblSites.Max(p => p.SiteID) + 1;

                // fill in the data
                this.SiteID = t_site.SiteID;
                t_site.SiteName = this.SiteName;
                t_site.Street = this.Street;
                t_site.City = this.City;
                t_site.State = this.State;
                t_site.ZipCode = this.ZipCode;
                oDc.tblSites.Add(t_site);
                oDc.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(int id)
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                var site = (from p in oDc.tblSites
                            where p.SiteID == id
                            select p).FirstOrDefault();

                if (site != null)
                {
                    site.SiteID = this.SiteID;
                    site.SiteName = this.SiteName;
                    site.Street = this.Street;
                    site.City = this.City;
                    site.State = this.State;
                    site.ZipCode = this.ZipCode;
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void LoadById(int id)
        {
            LFGuestSystemEntities db = new LFGuestSystemEntities();
            var s = (from p in db.tblSites
                     where p.SiteID == id
                     select new
                     {
                         p.SiteID,
                         p.SiteName,
                         p.Street,
                         p.City,
                         p.State,
                         p.ZipCode
                     }).FirstOrDefault();

            this.SiteID = s.SiteID;
            this.SiteName = s.SiteName;
            this.Street = s.Street;
            this.City = s.City;
            this.State = s.State;
            this.ZipCode = s.ZipCode;
        }
    }

    public class CSiteList:List<CSite>
    {
        public void Load()
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();

            foreach(tblSite tsite in oDc.tblSites)
            {
                CSite osite = new CSite();
                osite.SiteID = tsite.SiteID;
                osite.SiteName = tsite.SiteName;
                osite.Street = tsite.Street;
                osite.City = tsite.City;
                osite.State = tsite.State;
                osite.ZipCode = tsite.ZipCode;
                Add(osite);

            }
            //var sites = (from s in oDc.tblSites
            //             select new
            //             {
            //                 s.SiteID,
            //                 s.SiteName,
            //                 s.Street,
            //                 s.City,
            //                 s.State,
            //                 s.ZipCode
            //             }).ToList();
            //foreach(var si in sites)
            //{
            //    CSite oSite = new CSite(si.SiteID, si.SiteName, si.Street, si.City, si.State, si.ZipCode);
            //    Add(oSite);
                
            //}

        }

    }

}
