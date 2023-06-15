namespace ISPTF.Models.ExportLC
{
    public class PEXLCAcceptTermBillDeleteRequest
    {
        public string EXPORT_LC_NO { get; set; }
        public string EVENT_DATE { get; set; }
        public string WithOutFlag { get; set; }
        public string ADJUST_LC_REF { get; set; }
        public string Wref_Bank_ID { get; set; }
        public string FACNO { get; set; }
        public string DRAFT_CCY { get; set; }
        public double DRAFT_AMT { get; set; }
        public string VOUCH_ID { get; set; }
    }
}