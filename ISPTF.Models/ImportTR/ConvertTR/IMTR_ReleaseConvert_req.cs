using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
	public class IMTR_ReleaseConvert_req
	{
		public string? RefNumber { get; set; }
		public string? RecType { get; set; }
		public int? TRSeqno { get; set; }
		public string? CenterID { get; set; }
		public string? DMS { get; set; }
		public string? Event { get; set; }
		public string? UserCode {get;set;}
		public DateTime? EventDate { get; set; }
		public DateTime? LastIntDate { get; set; }
		public string? TRCcy { get; set; }
		public double? TRAmount { get; set; }
		public double? TRBalance { get; set; }
		public double? BLIntAmt { get; set; }
		public string? CFRRate { get; set; }
		public string? IntRateCode { get; set; }
		public double? IntRate { get; set; }
		public double? IntSpread { get; set; }
		public string? Tx26 { get; set; }
		public double? PayAmount { get; set; }

    }
}
