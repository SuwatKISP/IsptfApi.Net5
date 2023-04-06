using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCReleaseReq
    {
        public string exporT_BC_NO { get; set; }
        public string centerID { get; set; }
        public DateTime EVENT_DATE { get; set; }
        public string? DRAFT_CCY { get; set; }
        public double? DRAFT_AMT { get; set; }
        public string? BENE_ID { get; set; }
        public double? TOT_NEGO_AMOUNT { get; set; }


    }
}
