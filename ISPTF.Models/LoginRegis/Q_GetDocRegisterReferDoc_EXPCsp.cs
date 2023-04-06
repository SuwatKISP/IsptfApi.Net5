using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferDoc_EXPCsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string ContNo { get; set; }
        public string DocCCY { get; set; }
        public double DocAmount { get; set; }
        public DateTime ContDate { get; set; }
        public string Cust_Code { get; set; }
        public string CUST_NAME { get; set; }
    }
}
