namespace ISPTF.Models.Controllers.ExportBC
{
    public class PEXBCReverseCollectionReleaseReq
    {
		public string? EXPORT_BC_NO { get; set; }
		public int? EVENT_NO { get; set; }
		public string? USER_ID { get; set; }
		public string? CenterID { get; set; }
		public string? VOUCHID { get; set; }
		public string? EVENTDATE { get; set; }
		public string? DRAFT_CCY { get; set; }
		public double? TOT_NEGO_AMT { get; set; }
		public double? TOTAL_NEGO_BAL_THB { get; set; }
		public string? BENE_ID { get; set; }
	}
}