using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCBCOverDueReleaseReq
    {
        public string EXPORT_BC_NO { get; set; }
        public string BENE_ID { get; set; }
        public string EVENT_NO { get; set; }
        public string USER_ID { get; set; }
        public string CenterID { get; set; }
        public string VOUCHID { get; set; }
        public string EVENTDATE { get; set; }
        public string TOTAL_NEGO_BAL_THB { get; set; }
        public string OBASEDAY { get; set; }
        public string INTCODE { get; set; }
        public string OINTDAY { get; set; }
        public string OINTRATE { get; set; }
        public string OINTSPDRATE { get; set; }
        public string OINTCURRATE { get; set; }
        public string INTBALANCE { get; set; }
        public string PRNBALANCE { get; set; }
        public string LASTINTDATE { get; set; }
        public string VALUE_DATE { get; set; }
        public string OVESEQNO { get; set; }
        public string AUTOOVERDUE { get; set; }
        public string INTFLAG { get; set; }
        public string DateStartAccru { get; set; }
        public string DateToStop { get; set; }
    }
}
