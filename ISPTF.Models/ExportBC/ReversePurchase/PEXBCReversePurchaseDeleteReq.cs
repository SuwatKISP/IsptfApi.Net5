﻿using System;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCReversePurchaseDeleteReq
    {
        public string? EXPORT_BC_NO { get; set; }
        public string? VOUCH_ID { get; set; }
        public DateTime? EVENT_DATE { get; set; }
    }
}
