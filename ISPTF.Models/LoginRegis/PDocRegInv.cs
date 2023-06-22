using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class PDocRegInv
    {
        public string? Reg_Docno { get; set; }
        public int? Reg_DocSeq { get; set; }
        public string? CustCode { get; set; }
        public string? InvNumber { get; set; }
        public double? InvAmount { get; set; }
        public double? InvUse { get; set; }

    }
}
