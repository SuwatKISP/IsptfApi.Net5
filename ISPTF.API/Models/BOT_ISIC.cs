using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class BOT_ISIC
    {
        public string CL_CODE { get; set; }
        public string CL_FI_CODE { get; set; }
        public string CL_FM_CODE { get; set; }
        public string CL_NM_THAI { get; set; }
        public string CL_NM_ENG { get; set; }
        public string CL_PCHILD { get; set; }
        public string ATTRIBUTE { get; set; }
        public short? SEQ_ID { get; set; }
        public short? LASTSEQ { get; set; }
        public string STATUS { get; set; }
        public DateTime? LASTUPDATE { get; set; }
        public string USERID { get; set; }
    }
}
