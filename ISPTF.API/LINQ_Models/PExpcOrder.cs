using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PExpcOrder
    {
        public string DocNo { get; set; }
        public int EventNo { get; set; }
        public int Seqno { get; set; }
        public string OrderCnty { get; set; }
        public string OrderName { get; set; }
    }
}
