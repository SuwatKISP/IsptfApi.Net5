using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pLog_Swift
    {
        public DateTime? SendDate { get; set; }
        public string FileName { get; set; }
        public string Login { get; set; }
        public string Event { get; set; }
        public string RefNo { get; set; }
        public int SeqNo { get; set; }
        public string Status { get; set; }
        public string ErrCode { get; set; }
        public string LoadFile { get; set; }
        public DateTime? LoadDate { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string Resend { get; set; }
    }
}
