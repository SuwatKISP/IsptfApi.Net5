using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pExdoc
    {
        public string EXLC_NO { get; set; }
        public int SEQNO { get; set; }
        public int EVENT_NO { get; set; }
        public string DOCUMENT_ID { get; set; }
        public string DOCUMENT_NAME { get; set; }
        public string FMail_No { get; set; }
        public string SMail_No { get; set; }
        public string MODULE_TYPE { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string CenterID { get; set; }
    }
}
