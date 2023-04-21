using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pIMBLDoc
    {
        public string CenterID { get; set; }
        public string ADNumber { get; set; }
        public int SeqNo { get; set; }
        public string DocDetails { get; set; }
        public string OrgCopy { get; set; }
        public string Copy { get; set; }
    }
}
