using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PLogSendMail1
    {
        public DateTime? SendDate { get; set; }
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
    }
}
