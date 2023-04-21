using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pSWSending
    {
        public string Login { get; set; }
        public string RefNumber { get; set; }
        public int Seqno { get; set; }
        public string DocNumber { get; set; }
        public string RecStatus { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventFlag { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocStatus { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
