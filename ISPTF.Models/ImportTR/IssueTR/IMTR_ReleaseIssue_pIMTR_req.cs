using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_ReleaseIssue_pIMTR_req
    {
        public string? CustCode { get; set;}
		public string? RefNumber { get; set; }
		public string? TRNumber { get; set; }
		public string? RecType { get; set; }
		public int? TRSeqno { get; set; }
		public string? PayFlag { get; set; }
		public double? BLInterest { get; set; }
		public double? BLIntAmt { get; set; }
		public double? IntBalance { get; set; }
		public double? AccruPending { get; set; }
		public double? FBCharge { get; set; }
		public string? PayMethod { get; set; }
		public double? FBInterest { get; set; }
		public string? EventMode { get; set; }
		public string? SGNumber { get; set; }
		public string? LCNumber { get; set; }
		public string? DocCcy { get; set; }
		public string? CenterID { get; set; }
		public string? UserCode { get; set; }

    }
}
