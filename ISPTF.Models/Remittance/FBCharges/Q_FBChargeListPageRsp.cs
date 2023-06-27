using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Remittance
{
    public class Q_FBChargeListPageRsp
    {
        public int RCount { get; set; }
        public string? DocNo { get; set; }
        public int? Seqno { get; set; }
        public string? Login { get; set; }
        public string? Event { get; set; }
        public string? Cust_Code { get; set; }
        public string? Cust_Name { get; set; }
        public DateTime? EventDate { get; set; }
        public string? RecStatus { get; set; }
        public string? RefNo { get; set; }
        public string? Cust_Bran { get; set; }
        
    }
}
