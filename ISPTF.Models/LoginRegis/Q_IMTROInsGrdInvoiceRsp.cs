using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_IMTROInsGrdInvoiceRsp
    {
        public string Customer { get; set; }
        public string InvGroup { get; set; }
        public string InvDate { get; set; }
        public string InvNumber { get; set; }
        public string InvCcy { get; set; }
        public double InvAmount { get; set; }
        public string InvSupply { get; set; }
        public double InvBalance { get; set; }
    }
}
