using System.Collections.Generic;

namespace ISPTF.Models.ShippingGuarantee
{
    public class IssueSGNewListPageResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_IssueSGNewListPageRsp> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
