using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleaseIssueOverDueBills_pDOMBE_req
    {
		public string? BENumber { get; set; }
		public int? BESeqno { get; set; }
		public DateTime? OverDueDate { get; set; }
		public DateTime? IntStartDate { get; set; }
		public string? IntFlag { get; set; }
		public double? IntRateCode { get; set; }
		public double? IntRate { get; set; }
		public double? IntSpread { get; set; }
		public int? IntBaseDay { get; set; }
		public string? CenterID { get; set; }
		public string? UserCode { get; set; }
	}
}
