namespace ISPTF.Models
{
    public class PEXLCPPaymentPPayDetailDataContainer
    {
        public pExlc PEXLC { get; set; }
        public pPayment PPAYMENT { get; set; }
        public pPayDetail[] PPAYDETAILS { get; set; }
    }
}