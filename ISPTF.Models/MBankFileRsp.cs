using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MBankFileRsp
    {
        public string Bank_Code { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Flag { get; set; }
        public string Bank_Status { get; set; }
        public string Bank_Ccy { get; set; }
        public string Bank_Swift { get; set; }
        public string Bank_Authen { get; set; }
        public string Bank_Rating { get; set; }
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
        public string Bank_LimitCode1 { get; set; }
        public string Bank_LimitCcy1 { get; set; }
        public double Bank_LimitAmt1 { get; set; }
        public string Bank_LimitCode2 { get; set; }
        public string Bank_LimitCcy2 { get; set; }
        public double Bank_LimitAmt2 { get; set; }
        public string Bank_LimitCode3 { get; set; }
        public string Bank_LimitCcy3 { get; set; }
        public double Bank_LimitAmt3 { get; set; }
        public string Bank_AcCcy1 { get; set; }
        public string Bank_AcCode1 { get; set; }
        public string Bank_AcName1 { get; set; }
        public string Bank_Nostro1 { get; set; }
        public string Bank_AcCcy2 { get; set; }
        public string Bank_AcCode2 { get; set; }
        public string Bank_AcName2 { get; set; }
        public string Bank_Nostro2 { get; set; }
        public string Bank_AcCcy3 { get; set; }
        public string Bank_AcCode3 { get; set; }
        public string Bank_AcName3 { get; set; }
        public string Bank_Nostro3 { get; set; }
        public double Bank_Rebate { get; set; }
        public double Bank_Nego { get; set; }
        public double Bank_Outsource { get; set; }
        public double Bank_Relay { get; set; }
        public double Bank_Reissue { get; set; }
        public string RecStatus { get; set; }
        public string Bank_Remark { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
