using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MCustType
    {
        public string CsTypeCode { get; set; }
        public string CsTypeName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
