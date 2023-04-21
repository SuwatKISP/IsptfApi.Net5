using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TMP_VolCorrIncome
    {
        public DateTime? VouchDate { get; set; }
        public string TranMod { get; set; }
        public string KeyNumber { get; set; }
        public string Reference { get; set; }
        public string CustCode { get; set; }
        public string TranAccount { get; set; }
        public string ERP_Acc_Code { get; set; }
        public string Ccy { get; set; }
        public string IncomeCcy { get; set; }
        public double? IncomeAmt { get; set; }
        public string AccName { get; set; }
        public string BName { get; set; }
        public string BCnty { get; set; }
        public string Corr_Bank { get; set; }
        public string Corr_BankName { get; set; }
        public string Corr_BankCnty { get; set; }
        public string OldModule { get; set; }
        public string RepType { get; set; }
        public DateTime? SaveDate { get; set; }
    }
}
