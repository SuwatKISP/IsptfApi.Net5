namespace ISPTF.Models.ExportLC
{
    public class PEXLCAcceptTermBillDeleteRequest
    {
        public string EXPORT_LC_NO { get; set; }
        public string EVENT_DATE { get; set; }
        public bool? WITHOUT_RECOURSE { get; set; }
        public string APPROVE_NO { get; set; }
        public string BANK_CODE { get; set; }
        public string FACILITY_NO { get; set; }
        public string DRAFT_CCY { get; set; }
        public double DRAFT_AMT { get; set; }
    }
}