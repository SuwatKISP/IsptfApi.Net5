using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpReveMaster
    {
        public DateTime? Tdate { get; set; }
        public string Tmodule { get; set; }
        public string TkeyNumber { get; set; }
        public string TaccNo { get; set; }
        public string TflagDue { get; set; }
        public double? Tdiscrec { get; set; }
        public double? Tcommrec { get; set; }
        public double? Tmprinc { get; set; }
        public double? Tmintrec { get; set; }
        public double? Tmintrecv { get; set; }
        public double? Tmintsusp { get; set; }
        public double? Tcommfee { get; set; }
        public double? Tpenafee { get; set; }
        public double? Totherfee { get; set; }
        public double? Tforntfee { get; set; }
        public double? Tinsufee { get; set; }
    }
}
