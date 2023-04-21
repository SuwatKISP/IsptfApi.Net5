using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mMapProductGFM
    {
        public string mProd_Mod { get; set; }
        public string mProd_Event { get; set; }
        public string mProd_EventNm { get; set; }
        public string mProd_Cond { get; set; }
        public string mProd_Code { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
