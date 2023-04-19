using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class BotIsic
    {
        public string ClCode { get; set; }
        public string ClFiCode { get; set; }
        public string ClFmCode { get; set; }
        public string ClNmThai { get; set; }
        public string ClNmEng { get; set; }
        public string ClPchild { get; set; }
        public string Attribute { get; set; }
        public short? SeqId { get; set; }
        public short? Lastseq { get; set; }
        public string Status { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Userid { get; set; }
    }
}
