using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewGendlc
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
        public double Commlc { get; set; }
        public double Cable { get; set; }
        public double Postage { get; set; }
        public double Payble { get; set; }
        public double PendingPayable { get; set; }
        public double Duty { get; set; }
        public double Commother { get; set; }
        public double Taxamt { get; set; }
        public double BalAmt { get; set; }
        public double? ExchRate { get; set; }
        public string LastReceiptNo { get; set; }
        public string Fcyrec { get; set; }
        public string PayFlag { get; set; }
        public string PayMentFlag { get; set; }
        public string Paymethod { get; set; }
        public string VoucherId { get; set; }
        public string Allocation { get; set; }
        public double Comover { get; set; }
        public double Comtran { get; set; }
        public double Comcerti { get; set; }
        public double Comeng { get; set; }
        public double Discfee { get; set; }
        public string AmendFlag { get; set; }
        public string CenterId { get; set; }
    }
}
