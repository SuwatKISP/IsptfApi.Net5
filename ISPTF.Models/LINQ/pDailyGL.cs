using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDailyGL
    {
        public DateTime VouchDate { get; set; }
        public string VouchID { get; set; }
        public int TranSeq { get; set; }
        public string TranDocNo { get; set; }
        public int TranDocseq { get; set; }
        public string TranAccount { get; set; }
        public string TranCcy { get; set; }
        public string TranNature { get; set; }
        public double? TranExch { get; set; }
        public double? TranAmount { get; set; }
        public string TranDesc { get; set; }
        public string TranRef { get; set; }
        public string TranMod { get; set; }
        public string TranEvent { get; set; }
        public string TranBran { get; set; }
        public string TranDept { get; set; }
        public string TranCenter { get; set; }
        public string TranStatus { get; set; }
        public string TranAllocate { get; set; }
        public string CustCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public string SendFlag { get; set; }
        public string TranCond { get; set; }
        public string Wref_Bank_ID { get; set; }
        public string GFMS_Map { get; set; }
        public string SBUCode { get; set; }
        public string RCCode { get; set; }
        public string ProdCode { get; set; }
        public string NostroBank { get; set; }
        public string LoanStat { get; set; }
        public string InvoiceNo { get; set; }
        public string Tag20Ref { get; set; }
        public double? AmtConvert { get; set; }
        public string GFMS_Bran { get; set; }
    }
}
