using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewCustLm
    {
        public string FacilityNo { get; set; }
        public string IspCcsNo { get; set; }
        public string IspRelatedAc { get; set; }
        public string LimitCode { get; set; }
        public double? CreditAmount { get; set; }
        public string ProdMod { get; set; }
        public string ProdRef { get; set; }
        public string CcsCcy { get; set; }
        public string CcsStat { get; set; }
        public string CcsLmType { get; set; }
        public string CustCode { get; set; }
        public string CustCcid { get; set; }
        public string CustCif { get; set; }
    }
}
