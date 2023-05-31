using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pIMLCAmend
    {
        public string CenterID { get; set; }
        public string LCNumber { get; set; }
        public string RecType { get; set; }
        public int LCSeqno { get; set; }
        public string Narr77A { get; set; }
        public string Amend79 { get; set; }
    }
}
