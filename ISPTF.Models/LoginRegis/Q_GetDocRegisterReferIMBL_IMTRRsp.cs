using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferIMBL_IMTRRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string BLNumber { get; set; }
        public string BLCcy { get; set; }
        public double? BLbalance { get; set; }
        public DateTime EventDate { get; set; }
        public string AdNumber { get; set; }
        public string LCNumber { get; set; }
        public string Cust_Code { get; set; }
        public string BLOverDue { get; set; }
        public string AppvNo { get; set; }
        public DateTime DueDate { get; set; }
        public string TenorDay { get; set; }
        public string BPOFlag { get; set; }

    }
}
