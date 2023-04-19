using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PLogUser
    {
        public DateTime LogDate { get; set; }
        public string LogTime { get; set; }
        public int SeqNo { get; set; }
        public string UserCode { get; set; }
        public string ComName { get; set; }
        public string Status { get; set; }
        public string CenterId { get; set; }
    }
}
