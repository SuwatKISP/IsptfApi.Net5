using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewTmpBack
    {
        public string TRNumber { get; set; }
        public string RecType { get; set; }
        public int? TRSeqno { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string RefNumber { get; set; }
        public double? IntBalance { get; set; }
        public double? AccruPending { get; set; }
        public string CustCode { get; set; }
        public string custAddr { get; set; }
        public string centerid { get; set; }
    }
}
