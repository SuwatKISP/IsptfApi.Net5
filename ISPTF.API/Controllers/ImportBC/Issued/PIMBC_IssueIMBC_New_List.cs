using System;

namespace ISPTF.API.Controllers.ImportBC
{
    internal class PIMBC_IssueIMBC_New_List
    {
        public int RCount { get; set; }
        public string BCNumber { get; set; }
        public string BCSeqno { get; set; }
        public string RecType { get; set; }
        public string CustCode { get; set; }
        public string Cust_Name { get; set; }
        public DateTime EventDate { get; set; }
        public string SGNumber { get; set; }
        public string RecStatus { get; set; }
        public string BCCcy { get; set; }
        public string BCBalance { get; set; }
        public string Ref1 { get; set; }
        public string Event { get; set; }
        public string Reg_Login { get; set; }
        public string Reg_Funct { get; set; }
        public DateTime? Reg_Date { get; set; }
        public string Reg_Time { get; set; }
        public string Reg_Docno { get; set; }
        public int? Reg_seq { get; set; }
        public string Reg_DocType { get; set; }
        public string Reg_RefType { get; set; }
        public string Reg_RefNo { get; set; }
        public string Reg_RefNo2 { get; set; }
        public string Reg_RefNo3 { get; set; }
        public double? Reg_RefAmt { get; set; }
        public string Reg_CustCode { get; set; }
        public string Reg_BankCode { get; set; }
        public string Reg_Ccy { get; set; }
        public double? Reg_CcyAmt { get; set; }
        public double? Reg_CcyBal { get; set; }
        public double? Reg_ExchRate { get; set; }
        public double? Reg_BhtAmt { get; set; }
        public double? Reg_Plus { get; set; }
        public double? Reg_Minus { get; set; }
        public double? Reg_Amt { get; set; }
        public double? Reg_Amt1 { get; set; }
        public string Reg_Tenor { get; set; }
        public string Reg_Appv { get; set; }
        public string Reg_Status { get; set; }
        public string Reg_RecStat { get; set; }
        public string Reg_FacilityNo { get; set; }
        public string Reg_AppvNo { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string CenterID { get; set; }
        public string ACCESS_ID { get; set; }
        public string Trade_ref_Number { get; set; }
        public string Edition_Number { get; set; }
        public string CIF { get; set; }
        public string WithOut { get; set; }
        public string WithOutFlag { get; set; }
        public string WithOutType { get; set; }
        public int? TenorDay { get; set; }
        public string BPOFlag { get; set; }
        public string Reg_RefNo4 { get; set; }
    }
}