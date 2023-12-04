using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_IssueDBE_NewSelect_SearchRate_rsp
    {
        public double? TxIntRate { get; set; }
        public double? TxSpread { get; set; }
        public double? TxCurInt { get; set; }
        public int? TxBaseDay { get; set; }
    }
}
