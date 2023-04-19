using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PRemCleanBill
    {
        public string Clnumber { get; set; }
        public string RecType { get; set; }
        public int SeqNo { get; set; }
        public string RecStatus { get; set; }
        public string InUse { get; set; }
        public DateTime? EventDate { get; set; }
        public string Event { get; set; }
        public string BankType { get; set; }
        public string TranStatus { get; set; }
        public string TranResult { get; set; }
        public string CustCode { get; set; }
        public string CustBran { get; set; }
        public string CustInfo { get; set; }
        public string CustAddr { get; set; }
        public string CustAc1 { get; set; }
        public string CustAc2 { get; set; }
        public string CustAc3 { get; set; }
        public double? CustTotal1 { get; set; }
        public double? CustTotal2 { get; set; }
        public double? CustTotal3 { get; set; }
        public string Clccy { get; set; }
        public string RateType { get; set; }
        public double? ExchRate { get; set; }
        public double? RevalueRate { get; set; }
        public double? ClccyAmt { get; set; }
        public double? ClbhtAmt { get; set; }
        public double? Plexchange { get; set; }
        public double? NostroCcyAmt { get; set; }
        public double? NostroRate { get; set; }
        public double? NostroAmt { get; set; }
        public double? CommCic { get; set; }
        public double? CommCip { get; set; }
        public double? CommLieu { get; set; }
        public double? DutyAmt { get; set; }
        public double? OthCharge { get; set; }
        public double? TotCharge { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public double? TotAmt { get; set; }
        public string PayType { get; set; }
        public string PaySubType { get; set; }
        public string PayMethod { get; set; }
        public string MixPayment { get; set; }
        public string Fcdacno { get; set; }
        public string FcdrecNo { get; set; }
        public double? Fcdamt { get; set; }
        public DateTime? DatePaid { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenAccFlag { get; set; }
        public DateTime? DateGenAcc { get; set; }
        public string VoucherId { get; set; }
        public string Remark { get; set; }
        public string Allocation { get; set; }
        public string CenterId { get; set; }
        public string CollectBank { get; set; }
        public string AgentName { get; set; }
        public DateTime? Cicdate { get; set; }
        public int? ItemNo { get; set; }
        public double? AgentCcyAmt { get; set; }
        public double? AgentRate { get; set; }
        public double? AgentFree { get; set; }
        public double? Postage { get; set; }
        public double? Courier { get; set; }
        public double? PayableStemp { get; set; }
        public double? CashAmt { get; set; }
        public double? ChqAmt { get; set; }
        public string ChqNo { get; set; }
        public string ChqBank { get; set; }
        public string ChqBranch { get; set; }
        public string ResultType { get; set; }
        public int? ItemResult { get; set; }
        public double? AmtResult { get; set; }
        public double? PayResult { get; set; }
        public double? RateResult { get; set; }
        public double? Expense { get; set; }
        public double? Penalty { get; set; }
        public string Description { get; set; }
        public string CollectType { get; set; }
    }
}
