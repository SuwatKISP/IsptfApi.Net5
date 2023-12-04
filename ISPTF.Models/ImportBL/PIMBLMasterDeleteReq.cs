using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBL
{
    public class PIMBLMasterDeleteReq
    {
        public string BLNumber { get; set; }
        public string BLSeqno { get; set; }
        public DateTime EventDate { get; set; }

    }
}
