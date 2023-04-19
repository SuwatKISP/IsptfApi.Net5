using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MMapProductGfm
    {
        public string MProdMod { get; set; }
        public string MProdEvent { get; set; }
        public string MProdEventNm { get; set; }
        public string MProdCond { get; set; }
        public string MProdCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
