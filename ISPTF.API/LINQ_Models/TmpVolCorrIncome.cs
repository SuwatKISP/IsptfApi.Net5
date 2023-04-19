using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpVolCorrIncome
    {
        public DateTime? VouchDate { get; set; }
        public string TranMod { get; set; }
        public string KeyNumber { get; set; }
        public string Reference { get; set; }
        public string CustCode { get; set; }
        public string TranAccount { get; set; }
        public string ErpAccCode { get; set; }
        public string Ccy { get; set; }
        public string IncomeCcy { get; set; }
        public double? IncomeAmt { get; set; }
        public string AccName { get; set; }
        public string Bname { get; set; }
        public string Bcnty { get; set; }
        public string CorrBank { get; set; }
        public string CorrBankName { get; set; }
        public string CorrBankCnty { get; set; }
        public string OldModule { get; set; }
        public string RepType { get; set; }
        public DateTime? SaveDate { get; set; }
    }
}
