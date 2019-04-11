using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckInManager.PL;
using System.ComponentModel;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace CheckInManager.BL
{
    public class CRole
    {
        public int ID { get; set; }
        public string Desc { get; set; }
        [DisplayName("This employee is active")]
        public bool isActive { get; set; }


        public CRole()
        {

        }

        public CRole(int id, string des)
        {
            ID = id;
            Desc = des;
        }

        public void Update()
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                var item = (from p in oDc.tblRoles
                            where p.RoleID == this.ID
                            select p).FirstOrDefault();

                if (item != null)
                {
                    item.RoleID = this.ID;
                    item.Description = this.Desc;
                    oDc.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }  
        
    }

    public class CRoleList : List<CRole>
    {
        public void Load()
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();

            var role = from p in oDc.tblRoles
                            orderby p.RoleID
                            select p;

            foreach (var s in role)
            {
                CRole e = new CRole();
                e.ID = s.RoleID;
                e.Desc = s.Description;
                

                this.Add(e);
            }
        }
    }
}
