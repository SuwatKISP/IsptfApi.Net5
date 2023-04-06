using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.BankFile
{
    public class MBankFileViewBankLimitRsp
    {
        public int RCount { get; set; }
        public string? Bank_Code { get; set; }
        public string? Bank_Name { get; set; }
        public string? Facility_No { get; set; }
        public string? Credit_Ccy { get; set; }
        public double? Avaliable { get; set; }
    }
}
