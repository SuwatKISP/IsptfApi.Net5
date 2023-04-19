using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MBankFile
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BankFlag { get; set; }
        public string BankStatus { get; set; }
        public string BankCcy { get; set; }
        public string BankSwift { get; set; }
        public string BankAuthen { get; set; }
        public string BankRating { get; set; }
        public string BankAdd1 { get; set; }
        public string BankAdd2 { get; set; }
        public string BankAdd3 { get; set; }
        public string BankAdd4 { get; set; }
        public string BankAddSw1 { get; set; }
        public string BankAddSw2 { get; set; }
        public string BankAddSw3 { get; set; }
        public string BankAddSw4 { get; set; }
        public string BankAddSw5 { get; set; }
        public string BankAddSw6 { get; set; }
        public string BankAddSw7 { get; set; }
        public string BankCity { get; set; }
        public string BankZip { get; set; }
        public string BankCnty { get; set; }
        public string BankLimitCode1 { get; set; }
        public string BankLimitCcy1 { get; set; }
        public double? BankLimitAmt1 { get; set; }
        public string BankLimitCode2 { get; set; }
        public string BankLimitCcy2 { get; set; }
        public double? BankLimitAmt2 { get; set; }
        public string BankLimitCode3 { get; set; }
        public string BankLimitCcy3 { get; set; }
        public double? BankLimitAmt3 { get; set; }
        public string BankAcCcy1 { get; set; }
        public string BankAcCode1 { get; set; }
        public string BankAcName1 { get; set; }
        public string BankNostro1 { get; set; }
        public string BankAcCcy2 { get; set; }
        public string BankAcCode2 { get; set; }
        public string BankAcName2 { get; set; }
        public string BankNostro2 { get; set; }
        public string BankAcCcy3 { get; set; }
        public string BankAcCode3 { get; set; }
        public string BankAcName3 { get; set; }
        public string BankNostro3 { get; set; }
        public double? BankRebate { get; set; }
        public double? BankNego { get; set; }
        public double? BankOutsource { get; set; }
        public double? BankRelay { get; set; }
        public double? BankReissue { get; set; }
        public string RecStatus { get; set; }
        public string BankRemark { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
