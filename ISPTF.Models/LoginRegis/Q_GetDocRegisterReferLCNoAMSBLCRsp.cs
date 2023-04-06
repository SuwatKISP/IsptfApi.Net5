using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferLCNoAMSBLCRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string SBLCNumber { get; set; }
        public string SBLCCcy { get; set; }
        public double? SBLCAmt { get; set; }
        public string Cust_Code { get; set; }

    }
}
