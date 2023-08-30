using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
	public class IMTR_ReleaseTROverDue_req
	{
		public string? RefNumber { get; set; }
		public string? RecType { get; set; }
		public int? TRSeqno { get; set; }
		public string? UserCode {get;set;}
		public DateTime? OverDueDate { get; set; }
		public double? ExchRate { get; set; }
		public double? IntBalance { get; set; }
		public double? BLExch { get; set; }
		public string? IntFlag { get; set; }
		public string? IntRateCode { get; set; }
		public double? IntRate { get; set; }
		public double? IntSpread { get; set; }
		public double? TRBalance { get; set; }

    }
}
