using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class IMBCNewListRsp
    {
        public int? RCount { get; set; }
        public string? Reg_Docno { get; set; }
        public string? Reg_Ccy { get; set; }
        public double? Reg_CcyBal { get; set; }
        public double? Reg_ExchRate { get; set; }
        public string? Reg_CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public string? Reg_RefNo { get; set; }
        public string? Reg_BankCode { get; set; }
        public string? Reg_DocType { get; set; }
        public string? Reg_AppvNo { get; set; }
        public string? Reg_RefNo3 { get; set; }

    }
}
