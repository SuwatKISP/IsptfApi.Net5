using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MControlBatch
    {
        public string TableName { get; set; }
        public DateTime? BatchDate { get; set; }
        public string ContFlag { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
