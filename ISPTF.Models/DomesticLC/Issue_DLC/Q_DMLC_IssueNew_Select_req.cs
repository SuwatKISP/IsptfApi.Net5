using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_IssueNew_Select_req
    {
        public string? ListType { get; set; }
        public string? LoadLC { get; set; }
        public string? CenterID { get; set; }
        public string? RegDocNo { get; set; }
        public string? CustCode { get; set; }
        public string? UserCode { get; set; }
    }
}
