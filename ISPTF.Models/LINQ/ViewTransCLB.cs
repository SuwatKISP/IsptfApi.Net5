using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewTransCLB
    {
        public string CLNumber { get; set; }
        public string CLCCy { get; set; }
        public double? CLCcyAmt { get; set; }
        public string Bran_Name { get; set; }
        public DateTime? CICDate { get; set; }
        public int? ItemNo { get; set; }
        public double? CcyAmt { get; set; }
        public double? BhtAmt { get; set; }
        public string RecType { get; set; }
        public string CollectBank { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Add2 { get; set; }
        public string Bank_Add3 { get; set; }
        public string Bank_Add4 { get; set; }
        public string Bran_Code { get; set; }
        public double? CLBComm { get; set; }
        public double? RevalueRate { get; set; }
        public double? ExchRate { get; set; }
    }
}
