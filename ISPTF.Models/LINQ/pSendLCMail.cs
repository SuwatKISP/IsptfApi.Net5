using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pSendLCMail
    {
        public DateTime SendDate { get; set; }
        public string ACCESS_ID { get; set; }
        public string LC_Number { get; set; }
        public string CustCode { get; set; }
        public string Status { get; set; }
    }
}
