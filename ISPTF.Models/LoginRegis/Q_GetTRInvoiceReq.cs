using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetTRInvoiceReq
    {
        public string CustCode { get; set; }
        public string InvNumber { get; set; }
        public string InvDate { get; set; }
    }
}
