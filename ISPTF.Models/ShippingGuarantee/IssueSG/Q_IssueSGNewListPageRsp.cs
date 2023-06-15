using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ShippingGuarantee
{
    public class Q_IssueSGNewListPageRsp

    {
        public int RCount { get; set; }
        public string? Reg_Docno { get; set; }
        public string? Reg_Ccy { get; set; }
        public double? Reg_CcyAmt { get; set; }
        public string? Reg_RefNo { get; set; }
        public string? Cust_Code { get; set; }
        public string? Cust_Name { get; set; }
        public string? Reg_AppvNo { get; set; }
        public string? Reg_DocType { get; set; }
        public string? Reg_RefType { get; set; }
        public string? Reg_RefNo2 { get; set; }
        public string? Reg_FacilityNo { get; set; }

    }
}
