﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportLC
{
    public class EXLCPurchasePaymentListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCPurchasePaymentListPageRsp> Data { get; set; }
    }
}
