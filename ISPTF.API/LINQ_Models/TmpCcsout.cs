using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class TmpCcsout
    {
        public DateTime? CcsDate { get; set; }
        public string CcsModule { get; set; }
        public string CcsFacNo { get; set; }
        public string CcsCcy { get; set; }
        public string CcsCust { get; set; }
        public string CcsAccNo { get; set; }
        public string CcsCrtype { get; set; }
        public double? CcsBalance { get; set; }
        public double? CcsCredit { get; set; }
        public string CcsAsDate { get; set; }
        public double? CcsAccrued { get; set; }
    }
}
