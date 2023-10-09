using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_GetDetailbyFac_InsGrdShare_rsp
    {
        public string? ShareCustomer { get; set; }
        public string? Share_Imp { get; set; }
        public string? Share_Exp { get; set; }
        public string? Share_Dlc { get; set; }
        public string? Share_LG { get; set; }
        public double? Share_Credit { get; set; }
        public double? Share_Used { get; set; }
        public string? Share_CCS { get; set; }
        public string? Share_Cust { get; set; }
        public string? Cust_Name { get; set; }
    }
}
