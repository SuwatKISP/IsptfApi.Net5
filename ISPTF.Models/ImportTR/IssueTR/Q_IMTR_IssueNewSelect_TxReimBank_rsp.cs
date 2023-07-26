using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_IssueNewSelect_TxReimBank_rsp
    {
        public string? Bank_Code { get; set; }
        public string? Bank_Name { get; set; }
        public string? Bank_City { get; set; }
        public string? Bank_Cnty { get; set; }
        public string? Bank_Add1 { get; set; } 
        public string? Bank_Add2 { get; set; }
        public string? Bank_Add3 { get; set; }
        public string? Bank_Add4 { get; set; }
        public string? Bank_Authen { get; set; }
        public string? Bank_AcCode1 { get; set; }
        public string? Bank_Swift { get; set; }
    }
}
