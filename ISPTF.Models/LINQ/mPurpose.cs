using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mPurpose
    {
        public string Pur_Code { get; set; }
        public string Pur_Desc { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
