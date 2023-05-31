using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pLog_SendMail1
    {
        public DateTime? SendDate { get; set; }
        public string SendTime { get; set; }
        public string SendTO { get; set; }
        public string SendCC { get; set; }
        public string SendBCC { get; set; }
        public string SendSJB { get; set; }
        public string SendMSG { get; set; }
        public string SendFile1 { get; set; }
        public string SendFile2 { get; set; }
        public string SendFile3 { get; set; }
        public string SendMod { get; set; }
        public string SendUser { get; set; }
        public string Response { get; set; }
    }
}
