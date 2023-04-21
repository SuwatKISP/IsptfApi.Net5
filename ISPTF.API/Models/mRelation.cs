using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mRelation
    {
        public string Rel_Code { get; set; }
        public string Rel_Desc { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
