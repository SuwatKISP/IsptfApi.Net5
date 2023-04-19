using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PBlogLmProduct
    {
        public string LrecType { get; set; }
        public int LlogSeq { get; set; }
        public string LbankCode { get; set; }
        public string LfacilityNo { get; set; }
        public int LseqNo { get; set; }
        public string LprodCode { get; set; }
        public string LprodLimit { get; set; }
        public DateTime? LstartDate { get; set; }
        public DateTime? LexpiryDate { get; set; }
        public double? LprodAmount { get; set; }
        public string LccsNo { get; set; }
        public string LccsRef { get; set; }
        public string LccsLimit { get; set; }
    }
}
