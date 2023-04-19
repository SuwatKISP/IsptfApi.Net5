using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpSumacc
    {
        public string AccCode { get; set; }
        public string IntAccCode { get; set; }
        public string AccName { get; set; }
        public string IntAccName { get; set; }
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public string EventName { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string DocNo { get; set; }
        public string DocNo1 { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string RecStatus { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorTerm { get; set; }
        public int? TenorType1 { get; set; }
        public string Centerid { get; set; }
        public string FlagDue { get; set; }
        public double? IntRate { get; set; }
        public double AccruCcy { get; set; }
        public DateTime? LastPayment { get; set; }
        public string PayType { get; set; }
        public double AccruPending { get; set; }
        public DateTime? PastDueDate { get; set; }
        public DateTime? OverdueDate { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public string UpdateDate { get; set; }
        public string Usercode { get; set; }
        public string ErpAccCode { get; set; }
        public string ErpIntAccCode { get; set; }
        public string ErpAccName { get; set; }
        public string ErpIntAccName { get; set; }
        public string ErpProd { get; set; }
        public string Locode { get; set; }
        public string SaleUnit { get; set; }
        public string BusiArea { get; set; }
        public string CostCenter { get; set; }
        public string Profit { get; set; }
        public string BusiLine { get; set; }
    }
}
