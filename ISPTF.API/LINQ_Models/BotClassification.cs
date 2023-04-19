using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class BotClassification
    {
        public string ClScmId { get; set; }
        public string ClScmNm { get; set; }
        public string ClId { get; set; }
        public string ClNmEng { get; set; }
        public string ClNmThai { get; set; }
        public string ClNmUsed { get; set; }
        public string PrnClId { get; set; }
        public string ClAttrib { get; set; }
        public decimal? SeqNo { get; set; }
        public short? SeqId { get; set; }
        public short? Lastseq { get; set; }
        public string Status { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Userid { get; set; }
        public int? Rwa { get; set; }
    }
}
