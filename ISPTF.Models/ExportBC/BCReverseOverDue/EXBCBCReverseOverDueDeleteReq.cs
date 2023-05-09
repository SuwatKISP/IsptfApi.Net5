using System;

namespace ISPTF.Models.ExportBC
{
	public class EXBCBCReverseOverDueDeleteReq

	{
		public string? EXPORT_BC_NO { get; set; }
		public string? BENE_ID { get; set; }
		public string? VOUCHID { get; set; }
		public DateTime? EVENT_DATE { get; set; }
	}
}
