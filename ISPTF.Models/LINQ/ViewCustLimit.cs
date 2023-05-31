using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewCustLimit
    {
        public string Cust_Code { get; set; }
        public string Facility_No { get; set; }
        public int? Seq_No { get; set; }
        public string Status { get; set; }
        public string RecStatus { get; set; }
        public string Limit_IMEX { get; set; }
        public string Limit_IMLC { get; set; }
        public string Limit_IMTR { get; set; }
        public string Limit_EXLC { get; set; }
        public string Limit_EXBC { get; set; }
        public string Limit_EXPC { get; set; }
        public string Limit_DLC { get; set; }
        public string Limit_IMP { get; set; }
        public string Limit_EXP { get; set; }
        public string CCS_No { get; set; }
        public string CLMS_Flag { get; set; }
    }
}
