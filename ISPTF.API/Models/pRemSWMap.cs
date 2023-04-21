using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pRemSWMap
    {
        public string SwifInID { get; set; }
        public DateTime? SwiftDate { get; set; }
        public string SwiftMT { get; set; }
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string CCY { get; set; }
        public DateTime? VaDate { get; set; }
        public double? Amount { get; set; }
        public string Tag20 { get; set; }
        public string Tag50 { get; set; }
        public string Tag50D { get; set; }
        public string Tag52 { get; set; }
        public string Tag53 { get; set; }
        public string Tag54 { get; set; }
        public string Tag57 { get; set; }
        public string Tag59 { get; set; }
        public string Tag59D { get; set; }
        public string Tag70 { get; set; }
        public string FLag { get; set; }
    }
}
