using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCCollectionPaymentListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCCollectionPaymentListPageRsp> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
