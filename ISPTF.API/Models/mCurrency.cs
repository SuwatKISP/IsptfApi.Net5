using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mCurrency
    {
        public string Ccy_Code { get; set; }
        public string Ccy_Name { get; set; }
        public int? Ccy_Base { get; set; }
        public string Ccy_GE { get; set; }
        public string Ccy_GEC { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string Ccy_SWDEC { get; set; }
    }
}
