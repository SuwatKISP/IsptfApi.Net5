using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCCollectionPaymentDeleteReq
    {
        public string EXPORTT_BC_NO { get; set; }
        public string VOUCH_ID { get; set; }
        public DateTime EVENT_DATE { get; set; }

    }
}
