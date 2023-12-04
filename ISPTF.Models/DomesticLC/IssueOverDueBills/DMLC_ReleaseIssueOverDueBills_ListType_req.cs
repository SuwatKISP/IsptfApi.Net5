using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleaseIssueOverDueBills_ListType_req
    {
        //public string? ListType { get; set; }
        public string? LoadBL { get; set; }
        public double? TxDraftAmt { get; set;}
        public double? TxExchRate { get; set;}
        public double? TxCCyInt { get; set; }
        public double? TxAccInt { get; set; }
        public double? TxBhtInt { get; set; }
    }
}
