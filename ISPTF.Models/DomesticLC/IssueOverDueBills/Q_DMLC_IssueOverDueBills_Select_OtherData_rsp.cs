using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_IssueOverDueBills_Select_OtherData_rsp
    {
        public int? txSeq { get; set; }
        public float? TxExchRate { get; set; }
        public string? TxRateCode { get; set; }
        public int? txBaseDay { get; set; }
        public float? txSpread { get; set; }
        public float? TxIntRate { get; set; }
        public float? TxCurInt { get; set; }
        public int? ChkFloat { get; set; }
        public float? TxDraftBht { get; set; }
    }
}
