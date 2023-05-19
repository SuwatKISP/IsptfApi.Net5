using System;

namespace ISPTF.Models.ExportBC
{
    public class EXPCPaymentOverDueReleaseReq
    {
		public string? EXPORT_BC_NO { get; set; }
		public DateTime? EVENT_DATE { get; set; }
		public string? USER_ID { get; set; }	
		public string? CenterID { get; set; }	
	}
}