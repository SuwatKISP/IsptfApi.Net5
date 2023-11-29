using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleaseEditAdjustBE_pDOMBE_req
    {
		public string? BENumber { get; set; }
		public string? RecType { get; set; }
		public int? BESeqno { get; set; }
		public DateTime? DueDate { get; set; }
		public string? TenorType { get; set; }
		public string? AutoOverDue { get; set; }
		public string? IntFlag { get; set; }
		public string? IntRateCode { get; set; }
		public double? IntRate { get; set; }
		public double? IntSpread { get; set; }
		public int? IntBaseDay { get; set; }
		public string? UserCode { get; set; }
		public string? CenterID { get; set; }
	}
}
