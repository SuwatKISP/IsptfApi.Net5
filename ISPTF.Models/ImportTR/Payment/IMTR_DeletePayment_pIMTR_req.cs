using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_DeletePayment_pIMTR_req
    {
        public string RefNumber { get; set; }
        public int TRSeqno { get; set; }
        public string TRNumber { get; set; }
        public DateTime? EventDate { get; set; }
        //public string? UserCode { get; set; }

    }
}
