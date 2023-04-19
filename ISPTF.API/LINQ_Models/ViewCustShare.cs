using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewCustShare
    {
        public string CustCode { get; set; }
        public string FacilityNo { get; set; }
        public string Status { get; set; }
        public string RecStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string LimitCode { get; set; }
        public int? SeqNo { get; set; }
        public string FacilityType { get; set; }
        public string RevolFlag { get; set; }
        public string ShareFlag { get; set; }
        public double? CreditAmount { get; set; }
        public double? CreditShare { get; set; }
        public double? ShareAmount { get; set; }
        public double? SuspAmount { get; set; }
        public string Remark { get; set; }
        public string ShareCust { get; set; }
        public string ShareLimit { get; set; }
        public double? ShareCredit { get; set; }
        public double? ShareUsed { get; set; }
        public string ParentId { get; set; }
        public string ReferCust { get; set; }
        public string ReferFacility { get; set; }
        public string LimitImex { get; set; }
        public string LimitImlc { get; set; }
        public string LimitImtr { get; set; }
        public string LimitExlc { get; set; }
        public string LimitExbc { get; set; }
        public string LimitExpc { get; set; }
        public string LimitDlc { get; set; }
        public string LimitImp { get; set; }
        public string LimitExp { get; set; }
        public string ShareCcs { get; set; }
    }
}
