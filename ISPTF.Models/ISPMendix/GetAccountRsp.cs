using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ISPMendix
{
    public class GetAccountRsp
    {
        public string? TransactionNo { get; set; }
        public string? WorkStationID { get; set; }
        public int? JournalSeq { get; set; }
    }
}
