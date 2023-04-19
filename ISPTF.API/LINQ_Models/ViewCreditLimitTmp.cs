using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewCreditLimitTmp
    {
        public string CustCode { get; set; }
        public string FacilityNo { get; set; }
        public string SeqNo { get; set; }
        public string CcsNo { get; set; }
        public string LimitCode { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string FacilityType { get; set; }
        public string ReferCust { get; set; }
        public string ReferFacility { get; set; }
        public string RevolFlag { get; set; }
        public string ShareFlag { get; set; }
        public string ShareType { get; set; }
        public string CreditCcy { get; set; }
        public double? CreditAmount { get; set; }
        public double? CreditShare { get; set; }
        public double? ShareAmount { get; set; }
        public double? SuspAmount { get; set; }
        public string Remark { get; set; }
        public string BlockCode { get; set; }
        public DateTime? BlockDate { get; set; }
        public string BlockNote { get; set; }
        public string RecStatus { get; set; }
        public string RecCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public string AuthCode { get; set; }
        public string ParentId { get; set; }
        public string UsingRec { get; set; }
        public double? HoldAmount { get; set; }
        public string Condition { get; set; }
        public string AutoRec { get; set; }
        public string Cfrrate { get; set; }
        public double? Cfrspread { get; set; }
        public double? EarAmount { get; set; }
        public double? OriginAmount { get; set; }
        public double? AvailableAmt { get; set; }
    }
}
