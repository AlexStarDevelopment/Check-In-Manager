using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInManager.BL
{
    public class CDashboard
    {
        //TODO
        public CReports Reports { get; set; }
    }

    public class CReports
    {
        //TODO
        public int ReportID;
        public string ReportName;
    }

    public class CReportsList : List<CReports>
    {
        public void Load()
        {
            //TODO 
            //ADD STUFFS
        }
    }
}
