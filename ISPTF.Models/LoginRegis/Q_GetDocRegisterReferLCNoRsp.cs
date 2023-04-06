using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferLCNoRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string LCNumber { get; set; }
        public string RefNo { get; set; }
        public string LCCcy { get; set; }
        public double LCBal { get; set; }
        public string BPOFlag { get; set; }
        public string CustCode { get; set; }


    }
}
