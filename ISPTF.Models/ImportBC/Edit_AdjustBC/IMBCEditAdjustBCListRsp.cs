﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class IMBCEditAdjustBCListRsp
    {
        public int? RCount { get; set; }
        public string? BCNumber { get; set; }
        public string? Ref1 { get; set; }
        public int? BCSeqno { get; set; }
        public string? Event { get; set; }
        public string? RecType { get; set; }
        public string? CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public DateTime? EventDate { get; set; }
        public string? Ref2 { get; set; }
        public string? RecStatus { get; set; }
        public string? BCCcy { get; set; }
        public double? BCBalance { get; set; }

    }
}
