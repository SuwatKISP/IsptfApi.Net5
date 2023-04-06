using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class PIMBCCollectRefundDeleteReq
    {
        public string BCNumber { get; set; }
        public string BCSeqno { get; set; }
        public DateTime EventDate { get; set; }

    }
}
