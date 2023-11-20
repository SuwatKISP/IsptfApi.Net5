using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_AmendAmount_Select_DefultCommRate_rsp
    {
        public double? TxCommRate { get; set; }
        public double? MinComm { get; set; }
        public double? NormalComm { get; set; }
        public double? TxPayable { get; set; }
    }
}
