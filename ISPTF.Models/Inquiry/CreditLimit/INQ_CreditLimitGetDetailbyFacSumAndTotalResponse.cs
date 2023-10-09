using System.Collections.Generic;

namespace ISPTF.Models.Inquiry
{
    public class INQ_CreditLimitGetDetailbyFacSumAndTotalResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Q_Inq_CreditLimit_GetDetailbyFac_DetailAndTotal_rsp Data { get; set; }

    }
}
