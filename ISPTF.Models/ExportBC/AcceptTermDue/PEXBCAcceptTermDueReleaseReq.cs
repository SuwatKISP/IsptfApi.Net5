using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCAcceptTermDueReleaseReq
    {
        public string EXPORT_BC_NO { get; set; }
        public int EVENT_NO { get; set; }
        public string VOUCH_ID { get; set; }
    }
}
