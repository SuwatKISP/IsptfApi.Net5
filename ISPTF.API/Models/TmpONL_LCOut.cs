using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpONL_LCOut
    {
        public string LC_Number { get; set; }
        public string LC_CCy { get; set; }
        public double? LC_Amount { get; set; }
        public double? LC_Available { get; set; }
        public double? Drawing_Amount { get; set; }
        public string Open_Date { get; set; }
        public string Last_Tran_date { get; set; }
        public string Expiry_Date { get; set; }
        public string Upload_Date { get; set; }
        public string Status { get; set; }
        public string BenName { get; set; }
        public string ACCESS_ID { get; set; }
        public string Trade_ref_Number { get; set; }
        public string Edition_Number { get; set; }
    }
}
