using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.BankFile
{
    public class MBankFileActiveRsp
    {
        public int RCount { get; set; }
        public string Bank_Code { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Add1 { get; set; }
        public string Bank_Add2 { get; set; }
        public string Bank_Add3 { get; set; }
        public string Bank_Add4 { get; set; }
        public string Bank_AddSw1 { get; set; }
        public string Bank_AddSw2 { get; set; }
        public string Bank_AddSw3 { get; set; }
        public string Bank_AddSw4 { get; set; }
        public string Bank_AddSw5 { get; set; }
        public string Bank_AddSw6 { get; set; }
        public string Bank_AddSw7 { get; set; }
        public string Bank_City { get; set; }
        public string Bank_Zip { get; set; }
        public string Bank_Cnty { get; set; }
        public string Bank_Swift { get; set; }
    }
}
