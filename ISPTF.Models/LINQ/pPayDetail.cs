using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pPayDetail
    {
        public string DpReceiptNo { get; set; }
        public int DpSeq { get; set; }
        public string DpPayName { get; set; }
        public double? DpPayAmt { get; set; }
        public double? DpExchRate { get; set; }
        public string DpRemark { get; set; }
        public double? DpIntRate { get; set; }
        public DateTime? DpFromDate { get; set; }
        public DateTime? DpToDate { get; set; }
        public string DpContract { get; set; }
    }
}
