using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferLCNoIMSGRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string LCNumber { get; set; }
        public string LCCcy { get; set; }
        public double LCAvalBal { get; set; }
        public DateTime DateIssue { get; set; }
        public string Cust_Code { get; set; }
        public string Cust_Name { get; set; }


    }
}
