using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MControlDate
    {
        public DateTime ContDate { get; set; }
        public DateTime? ContNextDate { get; set; }
        public string ContFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string UpdUser { get; set; }
        public int? Swseq { get; set; }
    }
}
