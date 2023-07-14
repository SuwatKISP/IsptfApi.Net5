using System.Collections.Generic;

namespace ISPTF.Models.Inquiry
{
    public class INQ_CreditLimitSumAndTotalResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Q_Inq_CreditLimit_SumAndTotal_rsp Data { get; set; }

    }
}
