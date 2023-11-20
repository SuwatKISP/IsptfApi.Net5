using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_IssueOverDueBills_Select_pDOMBEMaster_rsp
    {
        public string? BENumber { get; set; }
        public string? RecType { get; set; }
        public string? M_AutoOverDue { get; set; }
        public string? M_IntFlag { get; set; }
        public double? M_IntRate { get; set; }
        public string? M_IntRateCode { get; set; }
        public int? M_IntBaseDay { get; set; }
        public double? M_IntSpread { get; set; }
        public double? M_CurInt { get; set; }

    }
}
