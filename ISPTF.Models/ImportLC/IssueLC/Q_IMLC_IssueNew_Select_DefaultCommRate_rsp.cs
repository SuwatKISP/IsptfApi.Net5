using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_IssueNew_Select_DefaultCommRate_rsp
    {
        public double? TxCommRate { get; set; }
        public string? TypeComm { get; set; }
        public double? MinComm { get; set; }
        public double? NormalComm { get; set; }
        public double? TxCable { get; set; }
        public double? TxDutyAmt { get; set; }
        public double? TxPayable { get; set; }
    }
}
