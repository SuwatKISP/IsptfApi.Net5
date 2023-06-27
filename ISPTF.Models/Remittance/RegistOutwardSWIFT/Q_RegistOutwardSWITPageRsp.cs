using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Remittance
{
    public class Q_RegistOutwardSWITPageRsp
    {
        public int RCount { get; set; }
        public string RemRefNo { get; set; }
        public string RemBankRefNo { get; set; }
        public string Cust_Code { get; set; }
        public string CustInfo1 { get; set; }
        public string RecStatus { get; set; }
    }
}
