using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferDLC_IMTRRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string BENumber { get; set; }
        public string BECcy { get; set; }
        public double BEbalance { get; set; }
        public DateTime EventDate { get; set; }
        public string DLCNumber { get; set; }
        public string LCNumber { get; set; }
        public string Cust_Code { get; set; }
        public string BEOverDue { get; set; }
        public string AppvNo { get; set; }
        public DateTime DueDate { get; set; }
        public string TenorDay { get; set; }
        public string DocCCy { get; set; }
        public double BEAmount { get; set; }

    }
}
