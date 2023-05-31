using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mTranType
    {
        public string Tran_Code { get; set; }
        public string Tran_Desc { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
