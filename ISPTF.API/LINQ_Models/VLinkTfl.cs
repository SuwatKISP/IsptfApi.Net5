using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class VLinkTfl
    {
        public string CustCode { get; set; }
        public string IspCif { get; set; }
        public string TflCif { get; set; }
        public string CustName { get; set; }
        public string TflRef { get; set; }
        public string IspCcs { get; set; }
        public string TflCcs { get; set; }
        public string TflCcsRelate { get; set; }
        public string TflProd { get; set; }
        public string TflCur { get; set; }
        public decimal? TflAmt { get; set; }
        public string NewFac { get; set; }
    }
}
