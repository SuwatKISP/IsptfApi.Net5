using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Remittance
{
    public class Q_DraftMiscellaneousListPageRsp
    {
        public int RCount { get; set; }
        public string? RemTranNo { get; set; }
        public string? BankRefNo { get; set; }
        public string? Cust_Code { get; set; }
        public string? CustInfo1 { get; set; }
        public string? RecStatus { get; set; }
        public string? Rectype { get; set; }
        public int? Seqno { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
