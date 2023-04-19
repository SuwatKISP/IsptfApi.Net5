using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class Vfindkeyno
    {
        public string IspCustno { get; set; }
        public string IspCust { get; set; }
        public string TfCust { get; set; }
        public string TfRef { get; set; }
        public string IspProd { get; set; }
        public string TfProd { get; set; }
        public string IspCcs { get; set; }
        public string TfCcs { get; set; }
        public string IspRelate { get; set; }
        public string TfRelate { get; set; }
        public string IspCcy { get; set; }
        public string TfCcy { get; set; }
        public string IspFac { get; set; }
        public double? IspCramt { get; set; }
        public decimal? TfAmt { get; set; }
    }
}
