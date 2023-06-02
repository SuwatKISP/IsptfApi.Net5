using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.BankFile
{
    public class MBankFileActiveExportRsp
    {
        public int RCount { get; set; }
        public string Bank_Code { get; set; }
        public string Bank_Name { get; set; }
        public string Cnty_Name { get; set; }
        public string Bank_Add1 { get; set; }
        public string Bank_Add2 { get; set; }
        public string Bank_Add3 { get; set; }
        public string Bank_Add4 { get; set; }
        public string Bank_Address { get; set; }
        public string Bank_Authen { get; set; }

    }
}
