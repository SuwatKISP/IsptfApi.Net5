using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ISPMendix
{
    public class GetAccountRsp2
    {
        public class Header
        {
            public string? TransactionNo { get; set; }
            public DateTime? TransactionDateTime { get; set; }
            public string? SourceID { get; set; }
            public string? TellerID { get; set; }
        }
        public class Teller
        {
            public int? JournalSeq { get; set; }
            public string? ErrorCorrectionFlag { get; set; }
            public int? OriginalJournalSeq { get; set; }
            public DateTime? EffectiveDate { get; set; }
            public string? WorkStationID { get; set; }
            public string? TellerBranch { get; set; }
            public string? GLReconcileNo { get; set; }

        }  
        public class Data
        {
            public string? AccountNo { get; set; }
            public string? AccountType { get; set; }
            public double? TransactionAmount { get; set; }
            public string? ThirdPartyName { get; set; }
            public string? Remarks { get; set; }

        }



    }
}
