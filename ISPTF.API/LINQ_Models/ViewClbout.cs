using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewClbout
    {
        public DateTime? EventDate { get; set; }
        public string Clnumber { get; set; }
        public string RecType { get; set; }
        public string Event { get; set; }
        public int SeqNo { get; set; }
        public string BranCode { get; set; }
        public string BranName { get; set; }
        public DateTime? Cicdate { get; set; }
        public int? ItemNo { get; set; }
        public double? CcyAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? BhtAmt { get; set; }
        public string Description { get; set; }
        public string TranStatus { get; set; }
        public double? Postage { get; set; }
        public double? PayableStemp { get; set; }
        public string Clccy { get; set; }
        public string CustInfo { get; set; }
        public string AgentName { get; set; }
        public string CustCode { get; set; }
        public string CustAddr { get; set; }
        public double? ClccyAmt { get; set; }
        public double? Expr1 { get; set; }
        public string VoucherId { get; set; }
    }
}
