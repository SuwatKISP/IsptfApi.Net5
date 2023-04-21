using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewGroupGL
    {
        public DateTime VouchDate { get; set; }
        public string TranCenter { get; set; }
        public string TranDept { get; set; }
        public string TranMod { get; set; }
        public string TranEvent { get; set; }
        public string TranCcy { get; set; }
        public string TranAccount { get; set; }
        public string TranNature { get; set; }
        public string TranAllocate { get; set; }
        public double? SumCCY { get; set; }
        public double? SumTHB { get; set; }
    }
}
