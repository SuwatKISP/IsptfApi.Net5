using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mCustType
    {
        public string CsType_Code { get; set; }
        public string CsType_Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
