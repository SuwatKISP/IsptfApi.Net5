using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pExpcOrder
    {
        public string DocNo { get; set; }
        public int EventNo { get; set; }
        public int Seqno { get; set; }
        public string OrderCnty { get; set; }
        public string OrderName { get; set; }
    }
}
