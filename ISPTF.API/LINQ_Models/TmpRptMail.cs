using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpRptMail
    {
        public DateTime SendDate { get; set; }
        public string SendTime { get; set; }
        public string SendTo { get; set; }
        public string SendCc { get; set; }
        public string SendBcc { get; set; }
        public string SendSjb { get; set; }
        public string SendMsg { get; set; }
        public string SendFile1 { get; set; }
        public string SendFile2 { get; set; }
        public string SendFile3 { get; set; }
        public string SendMod { get; set; }
        public string SendUser { get; set; }
        public string Response { get; set; }
        public string SendPass { get; set; }
        public string SendFlag { get; set; }
        public string CustCode { get; set; }
        public string UserCode { get; set; }
    }
}
