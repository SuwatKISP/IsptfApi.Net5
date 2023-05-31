using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mLoCode
    {
        public string Lo_code { get; set; }
        public string Lo_Name { get; set; }
        public string Lo_RcCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
