using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class BOT_Classification
    {
        public string CL_SCM_ID { get; set; }
        public string CL_SCM_NM { get; set; }
        public string CL_ID { get; set; }
        public string CL_NM_ENG { get; set; }
        public string CL_NM_THAI { get; set; }
        public string CL_NM_USED { get; set; }
        public string PRN_CL_ID { get; set; }
        public string CL_ATTRIB { get; set; }
        public decimal? SEQ_NO { get; set; }
        public short? SEQ_ID { get; set; }
        public short? LASTSEQ { get; set; }
        public string STATUS { get; set; }
        public DateTime? LASTUPDATE { get; set; }
        public string USERID { get; set; }
        public int? RWA { get; set; }
    }
}
