using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MCurrency
    {
        public string CcyCode { get; set; }
        public string CcyName { get; set; }
        public int? CcyBase { get; set; }
        public string CcyGe { get; set; }
        public string CcyGec { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string CcySwdec { get; set; }
    }
}
