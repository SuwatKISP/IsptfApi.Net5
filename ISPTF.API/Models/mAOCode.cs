using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mAOCode
    {
        public string ao_code { get; set; }
        public string ao_name { get; set; }
        public string ao_rccode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
