using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewGENDLC
    {
        public DateTime? EventDate { get; set; }
        public string RecStatus { get; set; }
        public string Module { get; set; }
        public int Seqno { get; set; }
        public string Event { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double Balance { get; set; }
        public double COMMLC { get; set; }
        public double CABLE { get; set; }
        public double Postage { get; set; }
        public double PAYBLE { get; set; }
        public double Pending_Payable { get; set; }
        public double DUTY { get; set; }
        public double COMMOTHER { get; set; }
        public double TAXAMT { get; set; }
        public double balAmt { get; set; }
        public double? ExchRate { get; set; }
        public string LastReceiptNo { get; set; }
        public string FCYRec { get; set; }
        public string PayFlag { get; set; }
        public string PayMentFlag { get; set; }
        public string Paymethod { get; set; }
        public string VoucherID { get; set; }
        public string Allocation { get; set; }
        public double COMOVER { get; set; }
        public double COMTRAN { get; set; }
        public double COMCERTI { get; set; }
        public double COMENG { get; set; }
        public double DISCFEE { get; set; }
        public string AmendFlag { get; set; }
        public string CenterID { get; set; }
    }
}
