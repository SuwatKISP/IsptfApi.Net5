using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_Select_DefaultRate_rsp
    {
        public string? M_IntRateCode { get; set; }
        public double? M_IntRate { get; set; }
        public double? M_IntSpread { get; set; }
        public int? M_IntBaseDay { get; set; }
        public string? M_IntFlag { get; set; }

    }
}
