using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_GetDetailbyFac_TotalLiability_rsp
    {
        public double? TxOrigin { get; set; }
        public double? TxCredit { get; set; }
        public double? TxLiab { get; set; }
        public double? TxAppv { get; set; }
        public double? TxShare { get; set; }
        public double? TxHoldAmt { get; set; }
        public double? TxTotal { get; set; }
        public double? TxAvailable { get; set; }
        public double? TxOver { get; set; }
        public double? TxSusp { get; set; }
        public double? TxGroup { get; set; }
    }
}
