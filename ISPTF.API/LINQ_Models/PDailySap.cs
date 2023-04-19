using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PDailySap
    {
        public DateTime VouchDate { get; set; }
        public int RecNo { get; set; }
        public string TranCenter { get; set; }
        public string TranMod { get; set; }
        public string TranEvent { get; set; }
        public string TranCcy { get; set; }
        public string TranNature { get; set; }
        public string TranAccount { get; set; }
        public string TranAllocate { get; set; }
        public string TranBatch { get; set; }
        public double? TranAmt { get; set; }
        public double? TranThb { get; set; }
    }
}
