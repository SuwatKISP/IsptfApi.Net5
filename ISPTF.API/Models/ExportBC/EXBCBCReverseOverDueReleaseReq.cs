﻿using System;

namespace ISPTF.Models.Controllers.ExportBC
{
    public class EXBCBCReverseOverDueReleaseReq
    {
		public string? EXPORT_BC_NO { get; set; }
		public string? BENE_ID { get; set; }
		public int? EVENT_NO { get; set; }
		public string? VOUCHID { get; set; }
		public DateTime? EVENTDATE { get; set; }
		public double? TOTAL_NEGO_BAL_THB { get; set; }
		public int? TENOR_OF_COLL { get; set; }
		public DateTime? VALUE_DATE { get; set; }
		public string? CFRRate { get; set; }
		public string? IntRateCode { get; set; }
		public double? INT_BASE_RATE { get; set; }
		public double? INT_SPREAD_RATE { get; set; }
		public double? DISCOUNT_RATE { get; set; }
		public double? CURRENT_DIS_RATE { get; set; }
		public double? CURRENT_INT_RATE { get; set; }
	}
}