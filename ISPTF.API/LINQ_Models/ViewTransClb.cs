using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewTransClb
    {
        public string Clnumber { get; set; }
        public string Clccy { get; set; }
        public double? ClccyAmt { get; set; }
        public string BranName { get; set; }
        public DateTime? Cicdate { get; set; }
        public int? ItemNo { get; set; }
        public double? CcyAmt { get; set; }
        public double? BhtAmt { get; set; }
        public string RecType { get; set; }
        public string CollectBank { get; set; }
        public string BankName { get; set; }
        public string BankAdd2 { get; set; }
        public string BankAdd3 { get; set; }
        public string BankAdd4 { get; set; }
        public string BranCode { get; set; }
        public double? Clbcomm { get; set; }
        public double? RevalueRate { get; set; }
        public double? ExchRate { get; set; }
    }
}
