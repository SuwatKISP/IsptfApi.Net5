﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBL
{
    public class IMBLNewListRsp
    {
        public int? RCount { get; set; }
        public string? Reg_Docno { get; set; }
        public string? Reg_Ccy { get; set; }
        public double? Reg_CcyAmt { get; set; }
        public double? Reg_CcyBal { get; set; }
        public double? Reg_ExchRate { get; set; }
        public string? Reg_CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public string? Reg_RefNo { get; set; }
        public string? Reg_RefNo2 { get; set; }

    }
}
