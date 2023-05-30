using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pSWImpText
    {
        public string Login { get; set; }
        public string DocNumber { get; set; }
        public int Seqno { get; set; }
        public string MTNo { get; set; }
        public string FDNo { get; set; }
        public string TextData { get; set; }
    }
}
