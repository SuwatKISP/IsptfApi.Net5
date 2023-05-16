using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class EXBCBCOverDueReleaseReq
    {
		public string? EXPORT_BC_NO { get; set; }
		public string? BENE_ID { get; set; }
		public int? EVENT_NO { get; set; }
		public string? USER_ID { get; set; }
		public string? CenterID { get; set; }
		public string? VOUCHID { get; set; }
		public DateTime? EVENTDATE { get; set; }
		public double? TOTAL_NEGO_BAL_THB { get; set; }
		public int? OBASEDAY { get; set; }
		public string? INTCODE { get; set; }
		public int? OINTDAY { get; set; }
		public double? OINTRATE { get; set; }
		public double? OINTSPDRATE { get; set; }
		public double? OINTCURRATE { get; set; }
		public double? INTBALANCE { get; set; }
		public double? PRNBALANCE { get; set; }
		public DateTime? LASTINTDATE { get; set; }
		public DateTime? VALUE_DATE { get; set; }
		public int? OVESEQNO { get; set; }
		public string? AUTOOVERDUE { get; set; }
		public string? INTFLAG { get; set; }
		public DateTime? DateStartAccru { get; set; }
		public DateTime? DateToStop { get; set; }
	}
}
