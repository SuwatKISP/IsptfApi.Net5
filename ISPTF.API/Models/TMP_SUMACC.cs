using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TMP_SUMACC
    {
        public string ACC_CODE { get; set; }
        public string INT_ACC_CODE { get; set; }
        public string ACC_NAME { get; set; }
        public string INT_ACC_NAME { get; set; }
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
        public int? TENOR_TYPE { get; set; }
        public string CENTERID { get; set; }
        public string FlagDue { get; set; }
        public double? intRate { get; set; }
        public double AccruCcy { get; set; }
        public DateTime? LastPayment { get; set; }
        public string PayType { get; set; }
        public double AccruPending { get; set; }
        public DateTime? PastDueDate { get; set; }
        public DateTime? OverdueDate { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public string UPDATE_DATE { get; set; }
        public string USERCODE { get; set; }
        public string ERP_ACC_CODE { get; set; }
        public string ERP_INT_ACC_CODE { get; set; }
        public string ERP_ACC_NAME { get; set; }
        public string ERP_INT_ACC_NAME { get; set; }
        public string ERP_PROD { get; set; }
        public string LOCode { get; set; }
        public string Sale_Unit { get; set; }
        public string Busi_Area { get; set; }
        public string Cost_Center { get; set; }
        public string Profit { get; set; }
        public string Busi_Line { get; set; }
    }
}
