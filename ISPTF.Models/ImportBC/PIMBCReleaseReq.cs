using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class PIMBCReleaseReq
    {
        public string BCNumber { get; set; }
        public string? RecType { get; set; }
        public int BCSeqno { get; set; }
        public string? Event { get; set; }
        public string? AuthCode { get; set; }
    }
}
