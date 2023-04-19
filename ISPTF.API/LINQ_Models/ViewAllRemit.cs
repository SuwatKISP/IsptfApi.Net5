using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewAllRemit
    {
        public string RemrefNo { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? RemDate { get; set; }
        public string RecStatus { get; set; }
        public string RemType { get; set; }
        public string RemBank { get; set; }
        public string CustBran { get; set; }
        public string CustCode { get; set; }
        public string CustInfo1 { get; set; }
        public string RemCcy { get; set; }
        public DateTime? AuthDate { get; set; }
        public string ReceiptNo { get; set; }
        public string RateType { get; set; }
        public string Centerid { get; set; }
        public int Seqno { get; set; }
        public string RateFlag { get; set; }
        public string RateRemark { get; set; }
    }
}
