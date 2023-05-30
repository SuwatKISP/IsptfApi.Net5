using Newtonsoft.Json;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCPPaymentDataContainer
    {
        [JsonProperty("PEXBC")]
        public pExbc PEXBC;
        public pPayment PPAYMENT;
        public PEXBCPPaymentDataContainer()
        {
        }

        public PEXBCPPaymentDataContainer(pExbc pEXBC, pPayment pPayment)
        {
            PEXBC = pEXBC;
            PPAYMENT = pPayment;
        }
    }
}