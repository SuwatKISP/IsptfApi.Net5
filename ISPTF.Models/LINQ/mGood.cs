using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mGood
    {
        public string Goods_Code { get; set; }
        public string Goods_Desc { get; set; }
        public string Goods_Purpose { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
