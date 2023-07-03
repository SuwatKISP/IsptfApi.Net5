using System.Collections.Generic;

namespace ISPTF.Models.Inquiry
{
    public class INQ_CreditLimitGetDetailbyFacResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_Inq_CreditLimit_GetDetailbyFac_rsp> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
