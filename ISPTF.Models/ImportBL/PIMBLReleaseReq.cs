using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBL
{
    public class PIMBLReleaseReq
    {
        public string BLNumber { get; set; }
        public string? RecType { get; set; }
        public int BLSeqno { get; set; }
        public string? Event { get; set; }
        public string? AuthCode { get; set; }
    }
}
