﻿using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCAdviceDiscrepancyListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCAdviceDiscrepancyListPageRsp> Data { get; set; }
    }
}
