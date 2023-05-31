using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpReveMaster
    {
        public DateTime? TDate { get; set; }
        public string TModule { get; set; }
        public string TKeyNumber { get; set; }
        public string TAccNo { get; set; }
        public string TFlagDue { get; set; }
        public double? TDISCREC { get; set; }
        public double? TCOMMREC { get; set; }
        public double? TMPRINC { get; set; }
        public double? TMINTREC { get; set; }
        public double? TMINTRECV { get; set; }
        public double? TMINTSUSP { get; set; }
        public double? TCOMMFEE { get; set; }
        public double? TPENAFEE { get; set; }
        public double? TOTHERFEE { get; set; }
        public double? TFORNTFEE { get; set; }
        public double? TINSUFEE { get; set; }
    }
}
