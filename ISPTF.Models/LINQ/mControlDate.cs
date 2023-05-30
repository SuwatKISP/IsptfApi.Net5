using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mControlDate
    {
        public DateTime ContDate { get; set; }
        public DateTime? ContNextDate { get; set; }
        public string ContFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string UpdUser { get; set; }
        public int? SWSeq { get; set; }
    }
}
