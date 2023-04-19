using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MGood
    {
        public string GoodsCode { get; set; }
        public string GoodsDesc { get; set; }
        public string GoodsPurpose { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
