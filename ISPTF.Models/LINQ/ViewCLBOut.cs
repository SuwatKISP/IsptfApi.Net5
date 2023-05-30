using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewCLBOut
    {
        public DateTime? EventDate { get; set; }
        public string CLNumber { get; set; }
        public string RecType { get; set; }
        public string Event { get; set; }
        public int SeqNo { get; set; }
        public string BranCode { get; set; }
        public string Bran_Name { get; set; }
        public DateTime? CICDate { get; set; }
        public int? ItemNo { get; set; }
        public double? CcyAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? BhtAmt { get; set; }
        public string Description { get; set; }
        public string TranStatus { get; set; }
        public double? Postage { get; set; }
        public double? PayableStemp { get; set; }
        public string CLCCy { get; set; }
        public string Cust_Info { get; set; }
        public string AgentName { get; set; }
        public string Cust_Code { get; set; }
        public string Cust_Addr { get; set; }
        public double? CLCcyAmt { get; set; }
        public double? Expr1 { get; set; }
        public string VoucherID { get; set; }
    }
}
