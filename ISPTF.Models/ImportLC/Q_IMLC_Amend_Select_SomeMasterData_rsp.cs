using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_Amend_Select_SomeMasterData_rsp
    {
        public string? LCNumber { get; set; }
        public string? RecType { get; set; }
        public int? PeriodComm { get; set; }
        public DateTime? DateExpiry { get; set; }
        public string? PlaceExpiry { get; set; }
        public double? AllowPlus { get; set; }
        public double? AllowMinus { get; set; }

    }
}
