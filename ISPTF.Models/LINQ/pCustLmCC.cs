using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pCustLmCC
    {
        public string Cust_Code { get; set; }
        public string Facility_No { get; set; }
        public int SeqNo { get; set; }
        public string Prod_Mod { get; set; }
        public string Prod_Ref { get; set; }
        public string CCS_Ccy { get; set; }
        public string CCS_DocStat { get; set; }
        public string CCS_Stat { get; set; }
        public string CCS_No { get; set; }
        public string CCS_LmType { get; set; }
    }
}
