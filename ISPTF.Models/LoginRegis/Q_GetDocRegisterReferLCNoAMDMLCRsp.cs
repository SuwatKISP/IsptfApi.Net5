using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferLCNoAMDMLCRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string DLCNumber { get; set; }
        public string DLCCcy { get; set; }
        public double? DLCBal { get; set; }
        public string CustCode { get; set; }
        public double? DLCAvalBal { get; set; }
        public double? AllowPlus { get; set; }
        public double? AllowMinus { get; set; }

    }
}
