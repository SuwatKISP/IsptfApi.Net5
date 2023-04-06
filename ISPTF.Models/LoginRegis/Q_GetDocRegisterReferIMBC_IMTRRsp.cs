using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferIMBC_IMTRRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string BCNumber { get; set; }
        public string BCCcy { get; set; }
        public double? BCbalance { get; set; }
        public DateTime EventDate { get; set; }
        public string AdNumber { get; set; }
        public string LCNumber { get; set; }
        public string Cust_Code { get; set; }
        public double? SGBal { get; set; }
        public string SGNumber1 { get; set; }
        public double? SGBal1 { get; set; }
        public DateTime DueDate { get; set; }
        public string TenorDay { get; set; }
        public string INVNumber { get; set; }

    }
}
