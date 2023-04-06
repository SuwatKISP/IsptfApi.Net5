using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMSBLC
    // ไม่แน่ใจว่ามีการเรียกใช้หรือเปล่า หรือ copy มาไว้ผิด
{
    public class PSBLCGrdAdviceRsp
    {
        public string Customer { get; set; }
        public string SBLCNumber { get; set; }
        public string SBLCCcy { get; set; }
        public double? SBLCAmount { get; set; }
        public string Cust_Code { get; set; }
        public string SBLCStatus { get; set; }
        public string RecStatus { get; set; }
        public string RecType { get; set; }
    }
}
