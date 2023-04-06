using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegister
    {
        public string customer { get; set; }
        public string reg_DocNo { get; set; }
        public string reg_CCY { get; set; }
        public string reg_CCYAmt { get; set; }
        public string reg_Date { get; set; }
        public string cust_code { get; set; }
    }
}
