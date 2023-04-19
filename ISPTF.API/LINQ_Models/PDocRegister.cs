using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PDocRegister
    {
        public string RegLogin { get; set; }
        public string RegFunct { get; set; }
        public DateTime? RegDate { get; set; }
        public string RegTime { get; set; }
        public string RegDocno { get; set; }
        public int? RegSeq { get; set; }
        public string RegDocType { get; set; }
        public string RegRefType { get; set; }
        public string RegRefNo { get; set; }
        public string RegRefNo2 { get; set; }
        public string RegRefNo3 { get; set; }
        public double? RegRefAmt { get; set; }
        public string RegCustCode { get; set; }
        public string RegBankCode { get; set; }
        public string RegCcy { get; set; }
        public double? RegCcyAmt { get; set; }
        public double? RegCcyBal { get; set; }
        public double? RegExchRate { get; set; }
        public double? RegBhtAmt { get; set; }
        public double? RegPlus { get; set; }
        public double? RegMinus { get; set; }
        public double? RegAmt { get; set; }
        public double? RegAmt1 { get; set; }
        public string RegTenor { get; set; }
        public string RegAppv { get; set; }
        public string RegStatus { get; set; }
        public string RegRecStat { get; set; }
        public string RegFacilityNo { get; set; }
        public string RegAppvNo { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string CenterId { get; set; }
        public string AccessId { get; set; }
        public string TradeRefNumber { get; set; }
        public string EditionNumber { get; set; }
        public string Cif { get; set; }
        public string WithOut { get; set; }
        public string WithOutFlag { get; set; }
        public string WithOutType { get; set; }
        public int? TenorDay { get; set; }
        public string Bpoflag { get; set; }
        public string RegRefNo4 { get; set; }
    }
}
