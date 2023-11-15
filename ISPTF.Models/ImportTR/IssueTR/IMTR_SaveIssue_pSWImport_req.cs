using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveIssue_pSWImport_req
    {
        public string? DocNumber { get; set; }
        public string? RemitCcy { get; set; }
        public double? RemitAmt { get; set; }
        public double? DeductAmt { get; set; }
        public double? ChargeAmt { get; set; }
        public string? SwiftFile { get; set; }
        public string? MT103 { get; set; }
        public string? MT202 { get; set; }
        public string? MT734 { get; set; }
        public string? MT752 { get; set; }
        public string? MT754 { get; set; }
        public string? MT756 { get; set; }
        public string? MT799 { get; set; }
        public string? MT999 { get; set; }
        public string? MT412 { get; set; }
        public string? MT499 { get; set; }
        public string? MT202Cov { get; set; }
        public string? MT400 { get; set; }
        public string? BNet { get; set; }
        public string? ToNego { get; set; }
        public string? ToName { get; set; }
        public string? ToRefer { get; set; }
        public string? ToBank { get; set; }
        public string? ToWhom { get; set; }
        public string? F20 { get; set; }
        public string? F50K { get; set; }
        public string? F59 { get; set; }
        public string? Flag32 { get; set; }
        public string? Detail32 { get; set; }
    }
}
