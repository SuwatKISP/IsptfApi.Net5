using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SwiftPrintData_req
	{
		public string? TxDocNo { get; set; }
		public string? TxDocSeq { get; set; }
		public DateTime? cSysDate { get; set; }
		public string? UserCode { get; set; }
		public string? AuthCode { get; set; }
		public string? LbMT { get; set; }
	}
}
