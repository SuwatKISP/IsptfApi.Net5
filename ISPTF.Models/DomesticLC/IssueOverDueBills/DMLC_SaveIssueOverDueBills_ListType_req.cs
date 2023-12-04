using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveIssueOverDueBills_ListType_req
    {
        public string? ListType { get; set; }
        public string? LoadBL { get; set; }
        public int? TxIntDay { get; set;}
        public double? TxCCyInt { get; set;}
        public double? TxBhtInt { get; set; }
    }
}
