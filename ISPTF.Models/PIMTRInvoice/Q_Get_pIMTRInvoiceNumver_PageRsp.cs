using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMTRInvoice
{
    public class Q_Get_pIMTRInvoiceNumver_PageRsp
    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public  string InvGroup { get; set; }
        public DateTime InvDate { get; set; }
        public string Invnumber { get; set; }
        public string InvCcy { get; set; }
        public double InvAmount { get; set; }
        public string InvSupply { get; set; }
        public double InvBalance { get; set; }
        public double InvUse { get; set; }
        public string InvStatus { get; set; }
        public string TRFlag { get; set; }
        public string Cust_Code { get; set; }
        public string Cust_Name { get; set; }

    }
}
