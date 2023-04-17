using ISPTF.Models.LoginRegis;

namespace ISPTF.Models
{
    public class PDocRegisterCustomer
    {
        public string reg_Login { get; set; }
        public string reg_Funct { get; set; }
        public string reg_Docno { get; set; }
        public string? reg_Date { get; set; }
        public string? reg_Time { get; set; }
        public int? reg_seq { get; set; }
        public string? reg_DocType { get; set; }
        public string? reg_RefType { get; set; }
        public string? reg_RefNo { get; set; }
        public string? reg_RefNo2 { get; set; }
        public string? reg_RefNo3 { get; set; }
        public double? reg_RefAmt { get; set; }
        public string? reg_CustCode { get; set; }
        public string? reg_BankCode { get; set; }
        public string? reg_Ccy { get; set; }
        public double? reg_CcyAmt { get; set; }
        public double? reg_CcyBal { get; set; }
        public double? reg_ExchRate { get; set; }
        public double? reg_BhtAmt { get; set; }
        public double? reg_Plus { get; set; }
        public double? reg_Minus { get; set; }
        public double? reg_Amt { get; set; }
        public double? reg_Amt1 { get; set; }
        public string? reg_Tenor { get; set; }
        public string? reg_Appv { get; set; }
        public string? reg_Status { get; set; }
        public string? reg_RecStat { get; set; }
        public string? reg_FacilityNo { get; set; }
        public string? reg_AppvNo { get; set; }
        public string? remark { get; set; }
        //public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string? userCode { get; set; }
        //public string AuthDate { get; set; }
        public string? authCode { get; set; }
        public string? centerID { get; set; }
        public string? accesS_ID { get; set; }
        public string? trade_ref_Number { get; set; }
        public string? edition_Number { get; set; }
        public string? cif { get; set; }
        public string? withOut { get; set; }
        public string? withOutFlag { get; set; }
        public string? withOutType { get; set; }
        public int? tenorDay { get; set; }
        public string? bpoFlag { get; set; }
        public string? reg_RefNo4 { get; set; }
        public string? cust_Name { get; set; }
    }
}