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
        public string EVENT_NO { get; set; }
        public string @CenterID { get; set; }
        public string USER_ID { get; set; }

    }
}
