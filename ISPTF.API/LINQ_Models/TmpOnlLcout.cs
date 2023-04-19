using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class TmpOnlLcout
    {
        public string LcNumber { get; set; }
        public string LcCcy { get; set; }
        public double? LcAmount { get; set; }
        public double? LcAvailable { get; set; }
        public double? DrawingAmount { get; set; }
        public string OpenDate { get; set; }
        public string LastTranDate { get; set; }
        public string ExpiryDate { get; set; }
        public string UploadDate { get; set; }
        public string Status { get; set; }
        public string BenName { get; set; }
        public string AccessId { get; set; }
        public string TradeRefNumber { get; set; }
        public string EditionNumber { get; set; }
    }
}
