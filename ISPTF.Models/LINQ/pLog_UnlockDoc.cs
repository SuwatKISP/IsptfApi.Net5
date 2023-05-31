using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pLog_UnlockDoc
    {
        public DateTime UnDate { get; set; }
        public string UnTime { get; set; }
        public string UnFunc { get; set; }
        public string UnRefNo { get; set; }
        public string UnDetail { get; set; }
        public string UserCode { get; set; }
    }
}
