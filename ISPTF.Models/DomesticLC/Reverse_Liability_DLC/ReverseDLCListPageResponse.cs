﻿using System.Collections.Generic;

namespace ISPTF.Models.DomesticLC
{
    public class ReverseDLCListPageResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_ReverseDLCListPageRsp> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
